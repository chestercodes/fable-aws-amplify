module GraphQLTag

open Fable.Core

type GraphQLTag = interface end

let [<Import("*","graphql-tag")>] gql: string -> GraphQLTag = jsNative

