module App

open Feliz
open Elmish
open Feliz.Router
open AwsAppsync
open graphql
open GraphQLTag
open Api
open AwsExports
open Fable.Core

type ParsedRoute = 
    | HomeRoute
    | CallbackRoute of idToken: string * accessToken: string * expiresIn: int * tokenType: string

let searchParameters (parts: string) =
    parts.Split('&')
    |> Array.toList
    |> List.choose (fun x -> 
        match x.Split('=') with
        | [| k; v |] -> Some (k, v)
        | _ -> None
    )
    |> Map.ofList

let route (currentUrl: string list) =
    match currentUrl with
    | x when x.Length = 1 && x.[0].StartsWith("id_token") ->
        // id_token=XX.XX.XXX&access_token=XXX.XXX.XXX&expires_in=3600&token_type=Bearer
        let search = searchParameters x.[0]
        match search.TryFind "id_token", search.TryFind "access_token", search.TryFind "expires_in", search.TryFind "token_type" with
        | Some idToken, Some accessToken, Some expiresIn, Some tokenType ->
            CallbackRoute (idToken, accessToken, int expiresIn, tokenType)
        | _ -> HomeRoute    
    | _ -> HomeRoute

[<Emit("Math.random()")>]
let getRandomNumber() : float = jsNative

[<Emit("Math.floor($0)")>]
let floorOf (x: float) : float  = jsNative

let randomNumberBetween (a: float) (b: float) : float = 
    floorOf (getRandomNumber() * (b - a)) + a 

let pickOneRandomlyFrom (list: 'T list) =
    let i = randomNumberBetween 0.0 (float list.Length) |> int
    list.[i]

type AuthDetails = { AccessToken: string; IdToken: string; TokenType: string }
type TodoTask = { Id: TaskId; ListId: ListId; Title: string }
type TodoList = { Name: string; Id: ListId; Tasks: TodoTask list }

type State = {
    Auth: AuthDetails option;
    Client: AWSAppSyncClient option
    Lists: TodoList list option
    }

type Msg = 
    | UrlChanged of string list
    | HydrateClient of string
    | ClientHydrated of AWSAppSyncClient
    | GetLists
    | InitLists of InitListsQuery.InitGetTodoListModel list
    | CreateList
    | ListCreated
    | CreateTask of id:ListId
    | TaskCreated
    | DeleteList of id:ListId
    | ListDeleted
    | DeleteTask of id:TaskId
    | TaskDeleted
    | TodoTaskCreated of TodoTaskModel
    | TodoListCreated of TodoListModel
    | TodoTaskUpdated of TodoTaskModel
    | TodoListUpdated of TodoListModel
    | TodoTaskDeleted of TodoTaskModel
    | TodoListDeleted of TodoListModel
    | ErrorHappened of string

let errorHappened = fun x -> ErrorHappened (toError x).message

let init() =
    match (Router.currentUrl()) |> route with
    | CallbackRoute (idToken, accessToken, expiresIn, tokenType) ->
        let newState = {
            Auth = Some { IdToken = idToken; AccessToken = accessToken; TokenType = tokenType }
            Client = None
            Lists = None
        }
        newState,  Cmd.ofMsg (HydrateClient accessToken)
    | other ->
        {   Auth = None
            Client = None
            Lists = None }, Cmd.none

let mutable dispatchCapture: (Msg -> unit) = ignore
let graphqlSubscriptions:State -> Cmd<Msg> =
    fun initialState ->
        let sub dispatch =
            dispatchCapture <- dispatch
            ()
        Cmd.ofSub sub

let mutable onCreateTodoTask: obj option = None 
let mutable onCreateTodoList: obj option = None 
let mutable onUpdateTodoList: obj option = None 
let mutable onUpdateTodoTask: obj option = None 
let mutable onDeleteTodoList: obj option = None 
let mutable onDeleteTodoTask: obj option = None 

let setupSubscriptions (client: AWSAppSyncClient) =
    let handleError = fun (error: SubscriptionErrors) -> log error ; ()

    onCreateTodoTask <- Some (
        (client.subscribe ({
                query = gql subscriptions.onCreateTodoTask;
                AppSyncSubscriptionWrapper.variables = Some forOwner })
        ).subscribe ({ 
            next = fun (x: DataResponse<OnCreateTodoTask>) -> 
                TodoTaskCreated x.data.onCreateTodoTask |> dispatchCapture
            error = handleError })
    )
    onCreateTodoList <- Some (
        (client.subscribe ({
                query = gql subscriptions.onCreateTodoList;
                AppSyncSubscriptionWrapper.variables = Some forOwner })
        ).subscribe ({ 
            next = fun (x: DataResponse<OnCreateTodoList>) -> 
                TodoListCreated x.data.onCreateTodoList |> dispatchCapture
            error = handleError })
    )
    
    onDeleteTodoTask <- Some (
        (client.subscribe ({
                query = gql subscriptions.onDeleteTodoTask;
                AppSyncSubscriptionWrapper.variables = Some forOwner })
        ).subscribe ({ 
            next = fun (x: DataResponse<OnDeleteTodoTask>) -> 
                TodoTaskDeleted x.data.onDeleteTodoTask |> dispatchCapture
            error = handleError })
    )
    onDeleteTodoList <- Some (
        (client.subscribe ({
                query = gql subscriptions.onDeleteTodoList;
                AppSyncSubscriptionWrapper.variables = Some forOwner })
        ).subscribe ({ 
            next = fun (x: DataResponse<OnDeleteTodoList>) -> 
                TodoListDeleted x.data.onDeleteTodoList |> dispatchCapture
            error = handleError })
    )
    
    onUpdateTodoTask <- Some (
        (client.subscribe ({
                query = gql subscriptions.onUpdateTodoTask;
                AppSyncSubscriptionWrapper.variables = Some forOwner })
        ).subscribe ({ 
            next = fun (x: DataResponse<OnUpdateTodoTask>) -> 
                TodoTaskUpdated x.data.onUpdateTodoTask |> dispatchCapture
            error = handleError })
    )
    onUpdateTodoList <- Some (
        (client.subscribe ({
                query = gql subscriptions.onUpdateTodoList;
                AppSyncSubscriptionWrapper.variables = Some forOwner })
        ).subscribe ({ 
            next = fun (x: DataResponse<OnUpdateTodoList>) -> 
                TodoListUpdated x.data.onUpdateTodoList |> dispatchCapture
            error = handleError })
    )

let update msg state =
    match msg with
    | UrlChanged segments -> state, Cmd.none
    | HydrateClient accessToken ->
        let hydrateClientCmd = Cmd.OfPromise.either (getAppSyncClient accessToken).hydrated () ClientHydrated (fun _ -> ErrorHappened "failed to hydrate client")
        state, hydrateClientCmd
    | ClientHydrated client ->
        setupSubscriptions client

        let delayed (n: int) = 
            async { 
                do! Async.Sleep n
                return 0
            }
        // wait a bit for the subscriptions to be ready
        let delayedOk = Cmd.OfAsync.perform delayed 300 (fun _ -> GetLists)
        { state with Client = Some client }, delayedOk
    | GetLists ->
        let success = fun (x: DataResponse<InitListsQuery.InitGetListTodoLists>) ->
            InitLists (x.data.listTodoLists.items |> Array.toList)
        let cmd = Cmd.OfPromise.either (fun () -> state.Client.Value.query getLists) () success errorHappened
        state, cmd
    | InitLists lists ->
        let lists =
            lists
            |> List.map(fun a -> 
                let tasks =
                    a.tasks.items
                    |> Array.map (fun t -> { Id = TaskId t.id; Title = t.title; ListId = ListId t.todoListID })
                    |> Array.toList
                { Id = ListId a.id; Name = a.name; Tasks = tasks }
            )
        {state with Lists = Some lists}, Cmd.navigate("#")
    | CreateList ->
        let name = pickOneRandomlyFrom [ "Shopping list"; "Bucket list"; "Chore list"; "Packing list" ]
        let mutateCall = fun () -> createListCommand name |> state.Client.Value.mutate
        state, Cmd.OfPromise.either mutateCall () (fun _ -> ListCreated) errorHappened
    | ListCreated -> state, Cmd.none
    | CreateTask listId ->
        let title = pickOneRandomlyFrom [
            "Milk"; "Eggs"; "Bread"; "Banana"; "Butter"; "Cheese";
            "Swim with dolphins"; "Ride a dog sled"; "Go skydiving";
            "Sweep floors"; "Hoover"; "Wash dishes"; "Feed pets"; "Do washing";
            "Passport"; "Phone charger"; "EU adapter"; "Water bottle"; "Socks"; 
        ]
        let mutateCall = fun () -> createListTaskCommand listId title |> state.Client.Value.mutate
        state, Cmd.OfPromise.either mutateCall () (fun _ -> TaskCreated) errorHappened
    | TaskCreated -> state, Cmd.none
    | DeleteList id ->
        let mutateCall = fun () -> createDeleteTodoListCommand id |> state.Client.Value.mutate
        state, Cmd.OfPromise.either mutateCall () (fun _ -> ListDeleted) errorHappened
    | ListDeleted -> state, Cmd.none
    | DeleteTask id ->
        let mutateCall = fun () -> createDeleteTodoTaskCommand id |> state.Client.Value.mutate
        state, Cmd.OfPromise.either mutateCall () (fun _ -> TaskDeleted) errorHappened
    | TaskDeleted -> state, Cmd.none
    | TodoTaskCreated item ->
        let listId = ListId item.todoListID
        let taskId = TaskId item.id
        let lists =
            state.Lists
            |> Option.map(fun ls ->
                ls
                |> List.map (fun x ->
                    if x.Id = listId then
                        { x with Tasks = x.Tasks @ [ { Id = taskId; Title = item.title; ListId = listId } ] }
                    else x
                )
            )
        { state with Lists = lists }, Cmd.none
    | TodoListCreated item ->
        let newList = { Id = ListId item.id; Name = item.name; Tasks = [] }
        let lists = 
            state.Lists
            |> Option.map(fun l -> l @ [newList])
        { state with Lists = lists }, Cmd.none
    | TodoTaskUpdated item ->
        "TodoTaskUpdated" |> log
        state, Cmd.none
    | TodoListUpdated item ->
        "TodoListUpdated" |> log
        state, Cmd.none
    | TodoTaskDeleted item ->
        let taskId = TaskId item.id
        let lists =
            state.Lists
            |> Option.map(fun l ->
                l |> List.map (fun x ->
                    let tasks = x.Tasks |> List.filter (fun y -> y.Id <> taskId)
                    { x with Tasks = tasks }
                )
            )
        { state with Lists = lists }, Cmd.none
    | TodoListDeleted item ->
        let listId = ListId item.id
        let lists =
            state.Lists
            |> Option.map (fun l ->
                l |> List.filter (fun x -> x.Id <> listId)
            )
        { state with Lists = lists }, Cmd.none
    | ErrorHappened s ->
        log s
        state, Cmd.none

let redButton (text: string) click =
    Html.button [
        prop.style [ style.margin 3 ]
        prop.className "btn btn-danger"
        prop.onClick click
        prop.text text
    ]

let blueButton (text: string) click =
    Html.button [
        prop.style [ style.margin 3 ]
        prop.className "btn btn-primary"
        prop.onClick click
        prop.text text
    ]

let homeRender state dispatch =
    let renderLists lists = 
        lists
        |> List.map (fun list ->
            log list
            let tasks = 
                list.Tasks
                |> List.map (fun t ->
                    Html.div [
                        prop.className "row"
                        prop.children [
                            
                            Html.div [
                                prop.className "col"
                                prop.children [
                                    Html.h4 [
                                        prop.style [ style.marginLeft 40 ]
                                        prop.text t.Title
                                    ]
                                ]
                            ]
                            Html.div [
                                prop.className "col"
                                prop.children [
                                    redButton "delete task" (fun _ -> DeleteTask t.Id |> dispatch)
                                ]
                            ]
                        ]
                    ]
                ) 
            
            Html.div [
                prop.className "row"
                prop.children [
                    Html.div [
                        prop.className "col"
                        prop.children [
                            Html.h4 [
                                prop.style [ style.marginLeft 20 ]
                                prop.text list.Name
                            ]
                        ]
                    ]

                    Html.div [
                        prop.className "col"
                        prop.children [
                            redButton "delete list" (fun _ -> DeleteList list.Id |> dispatch)
                            blueButton "create task" (fun _ -> CreateTask list.Id |> dispatch)
                        ]
                    ]

                    Html.div tasks
                ]
            ]
        )

    Html.div [
        prop.className "container"
        prop.children [
            match state.Lists with
            | None -> 
                Html.div [
                    prop.className "row"
                    prop.children [
                        Html.p "Waiting for lists..."
                    ]
                ]
            | Some lists ->
                Html.div [
                    prop.className "row"
                    prop.children [
                        Html.div [
                            prop.className "col"
                            prop.children [
                                Html.h2 "Lists"
                            ]
                        ]
                        Html.div [
                            prop.className "col"
                            prop.children [
                                blueButton "create list" (fun _ -> CreateList |> dispatch)
                            ]
                        ]
                    ]
                ]
                
                Html.div (renderLists lists)
        ]
    ]

let render state dispatch =
    React.router [
        router.onUrlChanged (UrlChanged >> dispatch)

        router.children [
            Html.div [
                match state.Auth with
                | Some _ -> homeRender state dispatch
                | None -> 
                    let authUrl =
                        sprintf "https://%s/login?response_type=token&client_id=%s&redirect_uri=%s"
                            awsExports.oauth.domain
                            awsExports.aws_user_pools_web_client_id
                            awsExports.oauth.redirectSignIn

                    Html.div [
                        prop.className "container"
                        prop.children [
                            
                            Html.div [
                                prop.className "row"
                                prop.children [
                                    Html.a [
                                        prop.className "btn btn-primary"
                                        prop.href authUrl
                                        prop.text "Click to sign in"
                                    ]
                                ]
                            ]
                        ]
                    ]
            ]
        ]
    ]

