// ts2fable 0.7.1
module rec APIGenTypes
open System
open Fable.Core
open Fable.Core.JS

type Array<'T> = System.Collections.Generic.IList<'T>


type [<AllowNullLiteral>] CreateTodoListInput =
    abstract id: string option with get, set
    abstract name: string with get, set
    abstract owner: string option with get, set

type [<AllowNullLiteral>] ModelTodoListConditionInput =
    abstract name: ModelStringInput option with get, set
    abstract ``and``: Array<ModelTodoListConditionInput option> option with get, set
    abstract ``or``: Array<ModelTodoListConditionInput option> option with get, set
    abstract not: ModelTodoListConditionInput option with get, set

type [<AllowNullLiteral>] ModelStringInput =
    abstract ne: string option with get, set
    abstract eq: string option with get, set
    abstract le: string option with get, set
    abstract lt: string option with get, set
    abstract ge: string option with get, set
    abstract gt: string option with get, set
    abstract contains: string option with get, set
    abstract notContains: string option with get, set
    abstract between: Array<string option> option with get, set
    abstract beginsWith: string option with get, set
    abstract attributeExists: bool option with get, set
    abstract attributeType: ModelAttributeTypes option with get, set
    abstract size: ModelSizeInput option with get, set

type [<StringEnum>] [<RequireQualifiedAccess>] ModelAttributeTypes =
    | Binary
    | BinarySet
    | Bool
    | List
    | Map
    | Number
    | NumberSet
    | String
    | StringSet
    //| _null

type [<AllowNullLiteral>] ModelSizeInput =
    abstract ne: float option with get, set
    abstract eq: float option with get, set
    abstract le: float option with get, set
    abstract lt: float option with get, set
    abstract ge: float option with get, set
    abstract gt: float option with get, set
    abstract between: Array<float option> option with get, set

type [<AllowNullLiteral>] UpdateTodoListInput =
    abstract id: string with get, set
    abstract name: string option with get, set
    abstract owner: string option with get, set

type [<AllowNullLiteral>] DeleteTodoListInput =
    abstract id: string option with get, set

type [<AllowNullLiteral>] CreateTodoTaskInput =
    abstract id: string option with get, set
    abstract title: string with get, set
    abstract todoListID: string with get, set
    abstract owner: string option with get, set

type [<AllowNullLiteral>] ModelTodoTaskConditionInput =
    abstract title: ModelStringInput option with get, set
    abstract todoListID: ModelIDInput option with get, set
    abstract ``and``: Array<ModelTodoTaskConditionInput option> option with get, set
    abstract ``or``: Array<ModelTodoTaskConditionInput option> option with get, set
    abstract not: ModelTodoTaskConditionInput option with get, set

type [<AllowNullLiteral>] ModelIDInput =
    abstract ne: string option with get, set
    abstract eq: string option with get, set
    abstract le: string option with get, set
    abstract lt: string option with get, set
    abstract ge: string option with get, set
    abstract gt: string option with get, set
    abstract contains: string option with get, set
    abstract notContains: string option with get, set
    abstract between: Array<string option> option with get, set
    abstract beginsWith: string option with get, set
    abstract attributeExists: bool option with get, set
    abstract attributeType: ModelAttributeTypes option with get, set
    abstract size: ModelSizeInput option with get, set

type [<AllowNullLiteral>] UpdateTodoTaskInput =
    abstract id: string with get, set
    abstract title: string option with get, set
    abstract todoListID: string option with get, set
    abstract owner: string option with get, set

type [<AllowNullLiteral>] DeleteTodoTaskInput =
    abstract id: string option with get, set

type [<AllowNullLiteral>] ModelTodoListFilterInput =
    abstract id: ModelIDInput option with get, set
    abstract name: ModelStringInput option with get, set
    abstract owner: ModelStringInput option with get, set
    abstract ``and``: Array<ModelTodoListFilterInput option> option with get, set
    abstract ``or``: Array<ModelTodoListFilterInput option> option with get, set
    abstract not: ModelTodoListFilterInput option with get, set

type [<AllowNullLiteral>] ModelTodoTaskFilterInput =
    abstract id: ModelIDInput option with get, set
    abstract title: ModelStringInput option with get, set
    abstract todoListID: ModelIDInput option with get, set
    abstract owner: ModelStringInput option with get, set
    abstract ``and``: Array<ModelTodoTaskFilterInput option> option with get, set
    abstract ``or``: Array<ModelTodoTaskFilterInput option> option with get, set
    abstract not: ModelTodoTaskFilterInput option with get, set

type [<AllowNullLiteral>] CreateTodoListMutationVariables =
    abstract input: CreateTodoListInput with get, set
    abstract condition: ModelTodoListConditionInput option with get, set

type [<AllowNullLiteral>] CreateTodoListMutation =
    abstract createTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] UpdateTodoListMutationVariables =
    abstract input: UpdateTodoListInput with get, set
    abstract condition: ModelTodoListConditionInput option with get, set

type [<AllowNullLiteral>] UpdateTodoListMutation =
    abstract updateTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] DeleteTodoListMutationVariables =
    abstract input: DeleteTodoListInput with get, set
    abstract condition: ModelTodoListConditionInput option with get, set

type [<AllowNullLiteral>] DeleteTodoListMutation =
    abstract deleteTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] CreateTodoTaskMutationVariables =
    abstract input: CreateTodoTaskInput with get, set
    abstract condition: ModelTodoTaskConditionInput option with get, set

type [<AllowNullLiteral>] CreateTodoTaskMutation =
    abstract createTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] UpdateTodoTaskMutationVariables =
    abstract input: UpdateTodoTaskInput with get, set
    abstract condition: ModelTodoTaskConditionInput option with get, set

type [<AllowNullLiteral>] UpdateTodoTaskMutation =
    abstract updateTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] DeleteTodoTaskMutationVariables =
    abstract input: DeleteTodoTaskInput with get, set
    abstract condition: ModelTodoTaskConditionInput option with get, set

type [<AllowNullLiteral>] DeleteTodoTaskMutation =
    abstract deleteTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] GetTodoListQueryVariables =
    abstract id: string with get, set

type [<AllowNullLiteral>] GetTodoListQuery =
    abstract getTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] ListTodoListsQueryVariables =
    abstract filter: ModelTodoListFilterInput option with get, set
    abstract limit: float option with get, set
    abstract nextToken: string option with get, set

type [<AllowNullLiteral>] ListTodoListsQuery =
    abstract listTodoLists: ListTodoListsQueryListTodoLists option with get, set

type [<AllowNullLiteral>] GetTodoTaskQueryVariables =
    abstract id: string with get, set

type [<AllowNullLiteral>] GetTodoTaskQuery =
    abstract getTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] ListTodoTasksQueryVariables =
    abstract filter: ModelTodoTaskFilterInput option with get, set
    abstract limit: float option with get, set
    abstract nextToken: string option with get, set

type [<AllowNullLiteral>] ListTodoTasksQuery =
    abstract listTodoTasks: ListTodoTasksQueryListTodoTasks option with get, set

type [<AllowNullLiteral>] OnCreateTodoListSubscriptionVariables =
    abstract owner: string with get, set

type [<AllowNullLiteral>] OnCreateTodoListSubscription =
    abstract onCreateTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] OnUpdateTodoListSubscriptionVariables =
    abstract owner: string with get, set

type [<AllowNullLiteral>] OnUpdateTodoListSubscription =
    abstract onUpdateTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] OnDeleteTodoListSubscriptionVariables =
    abstract owner: string with get, set

type [<AllowNullLiteral>] OnDeleteTodoListSubscription =
    abstract onDeleteTodoList: CreateTodoListMutationCreateTodoList option with get, set

type [<AllowNullLiteral>] OnCreateTodoTaskSubscriptionVariables =
    abstract owner: string with get, set

type [<AllowNullLiteral>] OnCreateTodoTaskSubscription =
    abstract onCreateTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] OnUpdateTodoTaskSubscriptionVariables =
    abstract owner: string with get, set

type [<AllowNullLiteral>] OnUpdateTodoTaskSubscription =
    abstract onUpdateTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] OnDeleteTodoTaskSubscriptionVariables =
    abstract owner: string with get, set

type [<AllowNullLiteral>] OnDeleteTodoTaskSubscription =
    abstract onDeleteTodoTask: CreateTodoTaskMutationCreateTodoTask option with get, set

type [<AllowNullLiteral>] CreateTodoListMutationCreateTodoListTasks =
    abstract __typename: string with get, set
    abstract nextToken: string option with get, set

type [<AllowNullLiteral>] CreateTodoListMutationCreateTodoList =
    abstract __typename: string with get, set
    abstract id: string with get, set
    abstract name: string with get, set
    abstract owner: string option with get, set
    abstract tasks: CreateTodoListMutationCreateTodoListTasks option with get, set
    abstract createdAt: string with get, set
    abstract updatedAt: string with get, set

type [<AllowNullLiteral>] CreateTodoTaskMutationCreateTodoTaskTodoList =
    abstract __typename: string with get, set
    abstract id: string with get, set
    abstract name: string with get, set
    abstract owner: string option with get, set
    abstract createdAt: string with get, set
    abstract updatedAt: string with get, set

type [<AllowNullLiteral>] CreateTodoTaskMutationCreateTodoTask =
    abstract __typename: string with get, set
    abstract id: string with get, set
    abstract title: string with get, set
    abstract todoListID: string with get, set
    abstract owner: string option with get, set
    abstract todoList: CreateTodoTaskMutationCreateTodoTaskTodoList option with get, set
    abstract createdAt: string with get, set
    abstract updatedAt: string with get, set

type [<AllowNullLiteral>] ListTodoListsQueryListTodoLists =
    abstract __typename: string with get, set
    abstract items: Array<CreateTodoTaskMutationCreateTodoTaskTodoList option> option with get, set
    abstract nextToken: string option with get, set

type [<AllowNullLiteral>] ListTodoTasksQueryListTodoTasksItemsArray =
    abstract __typename: string with get, set
    abstract id: string with get, set
    abstract title: string with get, set
    abstract todoListID: string with get, set
    abstract owner: string option with get, set
    abstract createdAt: string with get, set
    abstract updatedAt: string with get, set

type [<AllowNullLiteral>] ListTodoTasksQueryListTodoTasks =
    abstract __typename: string with get, set
    abstract items: Array<ListTodoTasksQueryListTodoTasksItemsArray option> option with get, set
    abstract nextToken: string option with get, set
