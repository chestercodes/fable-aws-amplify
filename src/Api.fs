module Api

open AwsAppsync
open AwsExports
open Fable.Core.JS
open Fable.Core.JsInterop
open DataModel
open graphql
open GraphQLTag

type TaskId = TaskId of string
type ListId = ListId of string

let log x = Fable.Core.JS.console.log(x)

let getAppSyncClient jwtValue =
    let authOptions = createEmpty<AuthOptions>
    authOptions.``type`` <- authType
    authOptions.jwtToken <- Promise.resolve jwtValue
    
    // https://stackoverflow.com/a/62016089/4854368
    let appSyncOptions = createEmpty<AWSAppSyncClientOptions>
    appSyncOptions.region <- awsExports.aws_appsync_region
    appSyncOptions.url <-    awsExports.aws_appsync_graphqlEndpoint
    appSyncOptions.auth <- authOptions
    appSyncOptions.disableOffline <- true
    
    let cacheConfig = createObj[]

    awsAppsync.AWSAppSyncClient.Create (appSyncOptions, cacheConfig)


let createInput x =
    createObj [
        "input" ==> x
    ]

let createListCommand listName =
    let createListInput = createInput { CreateTodoListInput.name = listName; id=None; owner=None }
    { mutation = gql mutations.createTodoList; variables = Some createListInput }

let createListTaskCommand (ListId listId) title =
    let createListItemInput = createInput { CreateTodoTaskInput.todoListID = listId; title = title; id=None; owner=None }
    { mutation = gql mutations.createTodoTask; variables = Some createListItemInput }

let createDeleteTodoTaskCommand (TaskId id) =
    let createDeleteTodoTaskInput = createInput { DeleteTodoTaskInput.id = Some id }
    { mutation = gql mutations.deleteTodoTask; variables = Some createDeleteTodoTaskInput }

let createDeleteTodoListCommand (ListId id) =
    let createDeleteTodoListInput = createInput { DeleteTodoListInput.id = Some id }
    { mutation = gql mutations.deleteTodoList; variables = Some createDeleteTodoListInput }

let forOwner =
  // hard code this for now, to get this properly use the cognito GetUser endpoint once authenticated
  // https://stackoverflow.com/a/58686493/4854368
    createObj [
        "owner" ==> "chester"
    ]

let onCreateTodoList = { AppSyncSubscriptionWrapper.query = gql subscriptions.onCreateTodoList; variables = Some forOwner }
let onCreateTodoTask = { AppSyncSubscriptionWrapper.query = gql subscriptions.onCreateTodoTask; variables = Some forOwner }
let onUpdateTodoList = { AppSyncSubscriptionWrapper.query = gql subscriptions.onUpdateTodoList; variables = Some forOwner }
let onUpdateTodoTask = { AppSyncSubscriptionWrapper.query = gql subscriptions.onUpdateTodoTask; variables = Some forOwner }
let onDeleteTodoList = { AppSyncSubscriptionWrapper.query = gql subscriptions.onDeleteTodoList; variables = Some forOwner }
let onDeleteTodoTask = { AppSyncSubscriptionWrapper.query = gql subscriptions.onDeleteTodoTask; variables = Some forOwner }

open FSharp.Data.LiteralProviders
let [<Literal>] InitListsGql = TextFile.gql.``InitLists.gql``.Text

let getLists:AppSyncQueryWrapper<InitListsQuery.InitGetTodoListModel> = { query = gql InitListsGql; variables = None }

let toError x =
    let y: GraphQLError = downcast(box x)
    y

