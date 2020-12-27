namespace rec DataModel

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type ModelAttributeTypes =
    | [<CompiledName "binary">] Binary
    | [<CompiledName "binarySet">] Binaryset
    | [<CompiledName "bool">] Bool
    | [<CompiledName "list">] List
    | [<CompiledName "map">] Map
    | [<CompiledName "number">] Number
    | [<CompiledName "numberSet">] Numberset
    | [<CompiledName "string">] String
    | [<CompiledName "stringSet">] Stringset
    | [<CompiledName "_null">] Null

[<Fable.Core.StringEnum; RequireQualifiedAccess>]
type ModelSortDirection =
    | [<CompiledName "ASC">] Asc
    | [<CompiledName "DESC">] Desc

type ModelTodoTaskFilterInput =
    { id: Option<ModelIDInput>
      title: Option<ModelStringInput>
      todoListID: Option<ModelIDInput>
      owner: Option<ModelStringInput>
      ``and``: Option<list<Option<ModelTodoTaskFilterInput>>>
      ``or``: Option<list<Option<ModelTodoTaskFilterInput>>>
      not: Option<ModelTodoTaskFilterInput> }

type ModelIDInput =
    { ne: Option<string>
      eq: Option<string>
      le: Option<string>
      lt: Option<string>
      ge: Option<string>
      gt: Option<string>
      contains: Option<string>
      notContains: Option<string>
      between: Option<list<Option<string>>>
      beginsWith: Option<string>
      attributeExists: Option<bool>
      attributeType: Option<ModelAttributeTypes>
      size: Option<ModelSizeInput> }

type ModelSizeInput =
    { ne: Option<int>
      eq: Option<int>
      le: Option<int>
      lt: Option<int>
      ge: Option<int>
      gt: Option<int>
      between: Option<list<Option<int>>> }

type ModelStringInput =
    { ne: Option<string>
      eq: Option<string>
      le: Option<string>
      lt: Option<string>
      ge: Option<string>
      gt: Option<string>
      contains: Option<string>
      notContains: Option<string>
      between: Option<list<Option<string>>>
      beginsWith: Option<string>
      attributeExists: Option<bool>
      attributeType: Option<ModelAttributeTypes>
      size: Option<ModelSizeInput> }

type ModelTodoListFilterInput =
    { id: Option<ModelIDInput>
      name: Option<ModelStringInput>
      owner: Option<ModelStringInput>
      ``and``: Option<list<Option<ModelTodoListFilterInput>>>
      ``or``: Option<list<Option<ModelTodoListFilterInput>>>
      not: Option<ModelTodoListFilterInput> }

type CreateTodoListInput =
    { id: Option<string>
      name: string
      owner: Option<string> }

type ModelTodoListConditionInput =
    { name: Option<ModelStringInput>
      ``and``: Option<list<Option<ModelTodoListConditionInput>>>
      ``or``: Option<list<Option<ModelTodoListConditionInput>>>
      not: Option<ModelTodoListConditionInput> }

type UpdateTodoListInput =
    { id: string
      name: Option<string>
      owner: Option<string> }

type DeleteTodoListInput = { id: Option<string> }

type CreateTodoTaskInput =
    { id: Option<string>
      title: string
      todoListID: string
      owner: Option<string> }

type ModelTodoTaskConditionInput =
    { title: Option<ModelStringInput>
      todoListID: Option<ModelIDInput>
      ``and``: Option<list<Option<ModelTodoTaskConditionInput>>>
      ``or``: Option<list<Option<ModelTodoTaskConditionInput>>>
      not: Option<ModelTodoTaskConditionInput> }

type UpdateTodoTaskInput =
    { id: string
      title: Option<string>
      todoListID: Option<string>
      owner: Option<string> }

type DeleteTodoTaskInput = { id: Option<string> }

type ModelIntInput =
    { ne: Option<int>
      eq: Option<int>
      le: Option<int>
      lt: Option<int>
      ge: Option<int>
      gt: Option<int>
      between: Option<list<Option<int>>>
      attributeExists: Option<bool>
      attributeType: Option<ModelAttributeTypes> }

type ModelBooleanInput =
    { ne: Option<bool>
      eq: Option<bool>
      attributeExists: Option<bool>
      attributeType: Option<ModelAttributeTypes> }

type ModelFloatInput =
    { ne: Option<float>
      eq: Option<float>
      le: Option<float>
      lt: Option<float>
      ge: Option<float>
      gt: Option<float>
      between: Option<list<Option<float>>>
      attributeExists: Option<bool>
      attributeType: Option<ModelAttributeTypes> }

/// The error returned by the GraphQL backend
type ErrorType = { message: string }
