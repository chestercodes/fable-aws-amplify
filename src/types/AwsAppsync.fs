module AwsAppsync

open System
open Fable.Core
open Fable.Core.JS
open GraphQLTag

let authType = "AMAZON_COGNITO_USER_POOLS"

type AuthOptions =
    abstract ``type`` : string with get, set
    abstract jwtToken : Promise<string> with get, set
    //abstract jwtToken : Async<string> with get, set

type [<AllowNullLiteral>] AWSAppsyncGraphQLError =
    abstract errorType: string with get, set
    abstract data: obj option with get, set

type [<AllowNullLiteral>] AWSAppSyncClientOptions =
    abstract url: string with get, set
    abstract region: string with get, set
    abstract auth: AuthOptions with get, set
    abstract disableOffline: bool with get, set

type SubscriptionError =
    abstract message: string with get, set

type SubscriptionErrors =
    abstract errors: SubscriptionError[] with get, set

type Observer<'TResult> = { next: 'TResult -> unit; error: SubscriptionErrors -> unit; }
type Observable<'TResult> = { subscribe: Observer<'TResult> -> obj; }
type AppSyncSubscriptionWrapper<'TVariables> = { query: GraphQLTag; variables: 'TVariables option }

// https://github.com/awslabs/aws-mobile-appsync-sdk-js/blob/b9920f7404f656b4a49369fb337eb21ca48130a0/packages/aws-appsync/__tests__/client.ts#L278
type AppSyncQueryWrapper<'TVariables> = {
  query: GraphQLTag
  variables: 'TVariables option
  } with
  // https://stackoverflow.com/a/51316107/4854368
  member this.fetchPolicy = "no-cache"
  //member this.fetchPolicy = "network-only"

type AppSyncMutationWrapper<'TVariables> = { mutation: GraphQLTag; variables: 'TVariables option }

type [<AllowNullLiteral>] AWSAppSyncClient =
    abstract hydrated: unit -> Promise<AWSAppSyncClient>
    abstract isOfflineEnabled: unit -> bool
    abstract query: AppSyncQueryWrapper<'TVariables> -> Promise<'TResult>
    abstract mutate: AppSyncMutationWrapper<'TVariables> -> Promise<'TResult>
    abstract subscribe: AppSyncSubscriptionWrapper<'TVariables> -> Observable<'TResult>

type [<AllowNullLiteral>] AWSAppSyncClientStatic =
    [<Emit "new $0($1...)">] abstract Create: ?p0: AWSAppSyncClientOptions * ?cache: obj -> AWSAppSyncClient

type [<AllowNullLiteral>] GraphQLCallErrorLocation = 
    abstract line: int with get, set
    abstract column: int with get, set
    abstract sourceName: string option with get, set

type [<AllowNullLiteral>] GraphQLCallError = 
    abstract path: string option with get, set
    abstract message: string with get, set
    abstract locations: GraphQLCallErrorLocation[] with get, set

type [<AllowNullLiteral>] GraphQLNetworkErrorResultError = 
    abstract errorType: string with get, set
    abstract message: string with get, set

type [<AllowNullLiteral>] GraphQLNetworkErrorResult = 
    abstract errors: GraphQLNetworkErrorResultError[] with get, set

type [<AllowNullLiteral>] GraphQLNetworkError = 
    abstract name: string with get, set
    abstract statusCode: int with get, set
    abstract result: GraphQLNetworkErrorResult with get, set

type [<AllowNullLiteral>] GraphQLError = 
    //inherit exn
    abstract graphQLErrors: GraphQLCallError[] with get, set
    abstract networkError: GraphQLNetworkError option with get, set
    abstract message: string with get, set

type [<AllowNullLiteral>] IExports =
    abstract AWSAppSyncClient: AWSAppSyncClientStatic

let [<Import("*","aws-appsync")>] awsAppsync: IExports = jsNative


(*

global.WebSocket = require('ws');
require('es6-promise').polyfill();
require('isomorphic-fetch');

// Require exports file with endpoint and auth info
const aws_exports = require('./aws-exports').default;

// Require AppSync module
const AUTH_TYPE = require('aws-appsync/lib/link/auth-link').AUTH_TYPE;
const AWSAppSyncClient = require('aws-appsync').default;

const url = aws_exports.ENDPOINT;
const region = aws_exports.REGION;
const type = AUTH_TYPE.AWS_IAM;
const type = AUTH_TYPE.AMAZON_COGNITO_USER_POOLS;

// If you want to use API key-based auth
const apiKey = 'xxxxxxxxx';
// If you want to use a jwtToken from Amazon Cognito identity:
const jwtToken = 'xxxxxxxx';

// If you want to use AWS...
const AWS = require('aws-sdk');
AWS.config.update({
    region: aws_exports.REGION,
    credentials: new AWS.Credentials({
        accessKeyId: aws_exports.AWS_ACCESS_KEY_ID,
        secretAccessKey: aws_exports.AWS_SECRET_ACCESS_KEY
    })
});
const credentials = AWS.config.credentials;

// Import gql helper and craft a GraphQL query
const gql = require('graphql-tag');
const query = gql(`
query AllPosts {
allPost {
    __typename
    id
    title
    content
    author
    version
}
}`);

// Set up a subscription query
const subquery = gql(`
subscription NewPostSub {
newPost {
    __typename
    id
    title
    author
    version
}
}`);

// Set up Apollo client
const client = new AWSAppSyncClient({
    url: url,
    region: region,
    auth: {
        type: type,
        credentials: credentials,
    }
    //disableOffline: true      //Uncomment for AWS Lambda
});

client.hydrated().then(function (client) {
    //Now run a query
    client.query({ query: query })
    //client.query({ query: query, fetchPolicy: 'network-only' })   //Uncomment for AWS Lambda
        .then(function logData(data) {
            console.log('results of query: ', data);
        })
        .catch(console.error);

    //Now subscribe to results
    const observable = client.subscribe({ query: subquery });

    const realtimeResults = function realtimeResults(data) {
        console.log('realtime data: ', data);
    };

    observable.subscribe({
        next: realtimeResults,
        complete: console.log,
        error: console.log,
    });
});


*)

(*
    import React, { Component } from "react";
import "./App.css";
import "bootstrap/dist/css/bootstrap.min.css";
import logo from "./logo.svg";
import Amplify from "@aws-amplify/core";
import "@aws-amplify/pubsub";
import API, { graphqlOperation } from "@aws-amplify/api";
import aws_exports from "./aws-exports"; 
Amplify.configure(aws_exports);

const createMessage = `mutation createMessage($message: String!){
    createMessage(input:{message:$message}) {
    __typename
    id
    message
    createdAt
    }
}
`;

const onCreateMessage = `subscription onCreateMessage {
    onCreateMessage {
    __typename
    message
    }
}`;

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      message: "",
      value: "",
      display: false
    };
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  async componentDidMount() {
    this.subscription = API.graphql(
      graphqlOperation(onCreateMessage)
    ).subscribe({
      next: event => {
        if (event){
          console.log("Subscription: " + JSON.stringify(event.value.data, null, 2));
          this.setState({ display: true });
          this.setState({ message: event.value.data.onCreateMessage.message });
        }
      }
    });
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  async handleSubmit(event) {
    event.preventDefault();
    event.stopPropagation();
    const message = {
      id: "",
      message: this.state.value,
      createdAt: ""
    };
    const mutation = await API.graphql(
      graphqlOperation(createMessage, message)
    );
    console.log("Mutation: " + JSON.stringify(mutation.data, null, 2));
  }

  render() {
    return (
      <div className="App">
        <img src={logo} className="App-logo" alt="logo" />
        <div className="jumbotron jumbotron-fluid p-0">
          <h2 className="center">Broadcaster</h2>
        </div>
        <br />
        <div className="container">
          <form onSubmit={this.handleSubmit}>
            <div className="form-group">
              <input
                className="form-control form-control-lg"
                type="text"
                value={this.state.value}
                onChange={this.handleChange}
              />
            </div>
            <input
              type="submit"
              value="Submit"
              className="btn btn-primary"
            />
          </form>
        </div>
        <br />
        {this.state.display ? (
          <div className="container">
            <div className="card bg-success">
              <h3 className="card-text text-white p-2">
                {this.state.message}
              </h3>
            </div>
          </div>
        ) : null}
      </div>
    );
  }
}

export default App;
*)