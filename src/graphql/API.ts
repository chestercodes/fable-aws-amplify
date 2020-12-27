/* tslint:disable */
/* eslint-disable */
//  This file was automatically generated and should not be edited.

export type CreateTodoListInput = {
  id?: string | null,
  name: string,
  owner?: string | null,
};

export type ModelTodoListConditionInput = {
  name?: ModelStringInput | null,
  and?: Array< ModelTodoListConditionInput | null > | null,
  or?: Array< ModelTodoListConditionInput | null > | null,
  not?: ModelTodoListConditionInput | null,
};

export type ModelStringInput = {
  ne?: string | null,
  eq?: string | null,
  le?: string | null,
  lt?: string | null,
  ge?: string | null,
  gt?: string | null,
  contains?: string | null,
  notContains?: string | null,
  between?: Array< string | null > | null,
  beginsWith?: string | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
  size?: ModelSizeInput | null,
};

export enum ModelAttributeTypes {
  binary = "binary",
  binarySet = "binarySet",
  bool = "bool",
  list = "list",
  map = "map",
  number = "number",
  numberSet = "numberSet",
  string = "string",
  stringSet = "stringSet",
  _null = "_null",
}


export type ModelSizeInput = {
  ne?: number | null,
  eq?: number | null,
  le?: number | null,
  lt?: number | null,
  ge?: number | null,
  gt?: number | null,
  between?: Array< number | null > | null,
};

export type UpdateTodoListInput = {
  id: string,
  name?: string | null,
  owner?: string | null,
};

export type DeleteTodoListInput = {
  id?: string | null,
};

export type CreateTodoTaskInput = {
  id?: string | null,
  title: string,
  todoListID: string,
  owner?: string | null,
};

export type ModelTodoTaskConditionInput = {
  title?: ModelStringInput | null,
  todoListID?: ModelIDInput | null,
  and?: Array< ModelTodoTaskConditionInput | null > | null,
  or?: Array< ModelTodoTaskConditionInput | null > | null,
  not?: ModelTodoTaskConditionInput | null,
};

export type ModelIDInput = {
  ne?: string | null,
  eq?: string | null,
  le?: string | null,
  lt?: string | null,
  ge?: string | null,
  gt?: string | null,
  contains?: string | null,
  notContains?: string | null,
  between?: Array< string | null > | null,
  beginsWith?: string | null,
  attributeExists?: boolean | null,
  attributeType?: ModelAttributeTypes | null,
  size?: ModelSizeInput | null,
};

export type UpdateTodoTaskInput = {
  id: string,
  title?: string | null,
  todoListID?: string | null,
  owner?: string | null,
};

export type DeleteTodoTaskInput = {
  id?: string | null,
};

export type ModelTodoListFilterInput = {
  id?: ModelIDInput | null,
  name?: ModelStringInput | null,
  owner?: ModelStringInput | null,
  and?: Array< ModelTodoListFilterInput | null > | null,
  or?: Array< ModelTodoListFilterInput | null > | null,
  not?: ModelTodoListFilterInput | null,
};

export type ModelTodoTaskFilterInput = {
  id?: ModelIDInput | null,
  title?: ModelStringInput | null,
  todoListID?: ModelIDInput | null,
  owner?: ModelStringInput | null,
  and?: Array< ModelTodoTaskFilterInput | null > | null,
  or?: Array< ModelTodoTaskFilterInput | null > | null,
  not?: ModelTodoTaskFilterInput | null,
};

export type CreateTodoListMutationVariables = {
  input: CreateTodoListInput,
  condition?: ModelTodoListConditionInput | null,
};

export type CreateTodoListMutation = {
  createTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type UpdateTodoListMutationVariables = {
  input: UpdateTodoListInput,
  condition?: ModelTodoListConditionInput | null,
};

export type UpdateTodoListMutation = {
  updateTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type DeleteTodoListMutationVariables = {
  input: DeleteTodoListInput,
  condition?: ModelTodoListConditionInput | null,
};

export type DeleteTodoListMutation = {
  deleteTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type CreateTodoTaskMutationVariables = {
  input: CreateTodoTaskInput,
  condition?: ModelTodoTaskConditionInput | null,
};

export type CreateTodoTaskMutation = {
  createTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type UpdateTodoTaskMutationVariables = {
  input: UpdateTodoTaskInput,
  condition?: ModelTodoTaskConditionInput | null,
};

export type UpdateTodoTaskMutation = {
  updateTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type DeleteTodoTaskMutationVariables = {
  input: DeleteTodoTaskInput,
  condition?: ModelTodoTaskConditionInput | null,
};

export type DeleteTodoTaskMutation = {
  deleteTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type GetTodoListQueryVariables = {
  id: string,
};

export type GetTodoListQuery = {
  getTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type ListTodoListsQueryVariables = {
  filter?: ModelTodoListFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListTodoListsQuery = {
  listTodoLists:  {
    __typename: "ModelTodoListConnection",
    items:  Array< {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken: string | null,
  } | null,
};

export type GetTodoTaskQueryVariables = {
  id: string,
};

export type GetTodoTaskQuery = {
  getTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type ListTodoTasksQueryVariables = {
  filter?: ModelTodoTaskFilterInput | null,
  limit?: number | null,
  nextToken?: string | null,
};

export type ListTodoTasksQuery = {
  listTodoTasks:  {
    __typename: "ModelTodoTaskConnection",
    items:  Array< {
      __typename: "TodoTask",
      id: string,
      title: string,
      todoListID: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null > | null,
    nextToken: string | null,
  } | null,
};

export type OnCreateTodoListSubscriptionVariables = {
  owner: string,
};

export type OnCreateTodoListSubscription = {
  onCreateTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnUpdateTodoListSubscriptionVariables = {
  owner: string,
};

export type OnUpdateTodoListSubscription = {
  onUpdateTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnDeleteTodoListSubscriptionVariables = {
  owner: string,
};

export type OnDeleteTodoListSubscription = {
  onDeleteTodoList:  {
    __typename: "TodoList",
    id: string,
    name: string,
    owner: string | null,
    tasks:  {
      __typename: "ModelTodoTaskConnection",
      nextToken: string | null,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnCreateTodoTaskSubscriptionVariables = {
  owner: string,
};

export type OnCreateTodoTaskSubscription = {
  onCreateTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnUpdateTodoTaskSubscriptionVariables = {
  owner: string,
};

export type OnUpdateTodoTaskSubscription = {
  onUpdateTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};

export type OnDeleteTodoTaskSubscriptionVariables = {
  owner: string,
};

export type OnDeleteTodoTaskSubscription = {
  onDeleteTodoTask:  {
    __typename: "TodoTask",
    id: string,
    title: string,
    todoListID: string,
    owner: string | null,
    todoList:  {
      __typename: "TodoList",
      id: string,
      name: string,
      owner: string | null,
      createdAt: string,
      updatedAt: string,
    } | null,
    createdAt: string,
    updatedAt: string,
  } | null,
};
