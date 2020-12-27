/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const getTodoList = /* GraphQL */ `
  query GetTodoList($id: ID!) {
    getTodoList(id: $id) {
      id
      name
      owner
      tasks {
        nextToken
      }
      createdAt
      updatedAt
    }
  }
`;
export const listTodoLists = /* GraphQL */ `
  query ListTodoLists(
    $filter: ModelTodoListFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listTodoLists(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        name
        owner
        createdAt
        updatedAt
      }
      nextToken
    }
  }
`;
export const getTodoTask = /* GraphQL */ `
  query GetTodoTask($id: ID!) {
    getTodoTask(id: $id) {
      id
      title
      todoListID
      owner
      todoList {
        id
        name
        owner
        createdAt
        updatedAt
      }
      createdAt
      updatedAt
    }
  }
`;
export const listTodoTasks = /* GraphQL */ `
  query ListTodoTasks(
    $filter: ModelTodoTaskFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listTodoTasks(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        title
        todoListID
        owner
        createdAt
        updatedAt
      }
      nextToken
    }
  }
`;
