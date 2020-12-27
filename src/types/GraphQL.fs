module graphql

open Fable.Core

type [<AllowNullLiteral>] Queries =
    abstract getTodoList: string with get, set
    abstract listTodoLists: string with get, set
    abstract getTodoTask: string with get, set
    abstract listTodoTasks: string with get, set

type [<AllowNullLiteral>] Mutations =
    abstract createTodoList: string with get, set
    abstract updateTodoList: string with get, set
    abstract deleteTodoList: string with get, set
    
    abstract createTodoTask: string with get, set
    abstract updateTodoTask: string with get, set
    abstract deleteTodoTask: string with get, set

type [<AllowNullLiteral>] Subscriptions =
    abstract onCreateTodoList: string with get, set
    abstract onUpdateTodoList: string with get, set
    abstract onDeleteTodoList: string with get, set
    
    abstract onCreateTodoTask: string with get, set
    abstract onUpdateTodoTask: string with get, set
    abstract onDeleteTodoTask: string with get, set

let [<Import("*","../graphql/queries")>] queries: Queries = jsNative
let [<Import("*","../graphql/mutations")>] mutations: Mutations = jsNative
let [<Import("*","../graphql/subscriptions")>] subscriptions: Subscriptions = jsNative

type [<AllowNullLiteral>] TodoListModel =
    abstract id: string with get, set
    abstract name: string with get, set
    //abstract tasks: TodoTaskModel[] with get, set

type [<AllowNullLiteral>] TodoTaskModel =
    abstract id: string with get, set
    abstract title: string with get, set
    abstract todoListID: string with get, set
    abstract todoList: TodoListModel with get, set

type [<AllowNullLiteral>] ListTodoList =
    abstract items: TodoListModel[] with get, set

module InitListsQuery =
    type [<AllowNullLiteral>] TodoTaskSummaryModel =
        abstract id: string with get, set
        abstract title: string with get, set
        abstract todoListID: string with get, set

    type [<AllowNullLiteral>] TodoTaskSummaryModelItems =
        abstract items: TodoTaskSummaryModel[] with get, set

    type [<AllowNullLiteral>] InitGetTodoListModel =
        abstract id: string with get, set
        abstract name: string with get, set
        abstract tasks: TodoTaskSummaryModelItems with get, set

    type [<AllowNullLiteral>] InitGetListTodoListsArray =
        abstract items: InitGetTodoListModel[] with get, set
    
    type [<AllowNullLiteral>] InitGetListTodoLists =
        abstract listTodoLists: InitGetListTodoListsArray with get, set


type [<AllowNullLiteral>] ListTodoTask =
    abstract items: TodoTaskModel[] with get, set

type [<AllowNullLiteral>] ListTodoTasks =
    abstract listTodoTasks: ListTodoTask with get, set

type [<AllowNullLiteral>] OnCreateTodoList =
    abstract onCreateTodoList: TodoListModel with get, set

type [<AllowNullLiteral>] OnCreateTodoTask =
    abstract onCreateTodoTask: TodoTaskModel with get, set

type [<AllowNullLiteral>] OnUpdateTodoList =
    abstract onUpdateTodoList: TodoListModel with get, set

type [<AllowNullLiteral>] OnUpdateTodoTask =
    abstract onUpdateTodoTask: TodoTaskModel with get, set

type [<AllowNullLiteral>] OnDeleteTodoList =
    abstract onDeleteTodoList: TodoListModel with get, set

type [<AllowNullLiteral>] OnDeleteTodoTask =
    abstract onDeleteTodoTask: TodoTaskModel with get, set

type [<AllowNullLiteral>] DataResponse<'T> =
    abstract data: 'T with get, set
