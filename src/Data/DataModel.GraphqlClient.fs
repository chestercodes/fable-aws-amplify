namespace DataModel

open Fable.SimpleHttp
open Fable.SimpleJson

type GraphqlInput<'T> = { query: string; variables: Option<'T> }
type GraphqlSuccessResponse<'T> = { data: 'T }
type GraphqlErrorResponse = { errors: ErrorType list }

type DataModelGraphqlClient(url: string, headers: Header list) =
    new(url: string) = DataModelGraphqlClient(url, [ ])

