/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const createTodoList = /* GraphQL */ `
  mutation CreateTodoList(
    $input: CreateTodoListInput!
    $condition: ModelTodoListConditionInput
  ) {
    createTodoList(input: $input, condition: $condition) {
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
export const updateTodoList = /* GraphQL */ `
  mutation UpdateTodoList(
    $input: UpdateTodoListInput!
    $condition: ModelTodoListConditionInput
  ) {
    updateTodoList(input: $input, condition: $condition) {
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
export const deleteTodoList = /* GraphQL */ `
  mutation DeleteTodoList(
    $input: DeleteTodoListInput!
    $condition: ModelTodoListConditionInput
  ) {
    deleteTodoList(input: $input, condition: $condition) {
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
export const createTodoTask = /* GraphQL */ `
  mutation CreateTodoTask(
    $input: CreateTodoTaskInput!
    $condition: ModelTodoTaskConditionInput
  ) {
    createTodoTask(input: $input, condition: $condition) {
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
export const updateTodoTask = /* GraphQL */ `
  mutation UpdateTodoTask(
    $input: UpdateTodoTaskInput!
    $condition: ModelTodoTaskConditionInput
  ) {
    updateTodoTask(input: $input, condition: $condition) {
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
export const deleteTodoTask = /* GraphQL */ `
  mutation DeleteTodoTask(
    $input: DeleteTodoTaskInput!
    $condition: ModelTodoTaskConditionInput
  ) {
    deleteTodoTask(input: $input, condition: $condition) {
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
