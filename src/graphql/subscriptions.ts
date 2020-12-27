/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const onCreateTodoList = /* GraphQL */ `
  subscription OnCreateTodoList($owner: String!) {
    onCreateTodoList(owner: $owner) {
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
export const onUpdateTodoList = /* GraphQL */ `
  subscription OnUpdateTodoList($owner: String!) {
    onUpdateTodoList(owner: $owner) {
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
export const onDeleteTodoList = /* GraphQL */ `
  subscription OnDeleteTodoList($owner: String!) {
    onDeleteTodoList(owner: $owner) {
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
export const onCreateTodoTask = /* GraphQL */ `
  subscription OnCreateTodoTask($owner: String!) {
    onCreateTodoTask(owner: $owner) {
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
export const onUpdateTodoTask = /* GraphQL */ `
  subscription OnUpdateTodoTask($owner: String!) {
    onUpdateTodoTask(owner: $owner) {
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
export const onDeleteTodoTask = /* GraphQL */ `
  subscription OnDeleteTodoTask($owner: String!) {
    onDeleteTodoTask(owner: $owner) {
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
