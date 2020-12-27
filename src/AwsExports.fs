module AwsExports

open Fable.Core

type OAuthObj =
    abstract domain: string with get, set
    abstract redirectSignIn: string with get, set

type AwsExportsObj =
    abstract aws_appsync_graphqlEndpoint: string with get, set
    abstract aws_appsync_region: string with get, set
    abstract aws_user_pools_web_client_id: string with get, set
    abstract oauth: OAuthObj with get, set

type AwsExportsInst =
    abstract ``default``: AwsExportsObj with get, set

let [<Import("*","./aws-exports.js")>] awsExportsInst: AwsExportsInst = jsNative
let awsExports = awsExportsInst.``default``


(*

{
    "aws_project_region": "eu-west-1",
    "aws_cognito_identity_pool_id": "eu-west-1:GUIDXXX",
    "aws_cognito_region": "eu-west-1",
    "aws_user_pools_id": "eu-west-1_XXXX",
    "aws_user_pools_web_client_id": "XXXX",
    "oauth": {
        "domain": "fablefelizamplify-local.auth.eu-west-1.amazoncognito.com",
        "scope": [
            "phone",
            "email",
            "openid",
            "profile",
            "aws.cognito.signin.user.admin"
        ],
        "redirectSignIn": "http://localhost:8080/",
        "redirectSignOut": "http://localhost:8080/",
        "responseType": "token"
    },
    "federationTarget": "COGNITO_USER_POOLS",
    "aws_appsync_graphqlEndpoint": "https://xxxx.appsync-api.eu-west-1.amazonaws.com/graphql",
    "aws_appsync_region": "eu-west-1",
    "aws_appsync_authenticationType": "API_KEY",
    "aws_appsync_apiKey": "da2-XXXXX"
};

*)
