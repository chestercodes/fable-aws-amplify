# fable-aws-amplify

This is the code for this blog post https://chester.codes/aws-amplify-fsharp-fable

## Rough steps taken

The steps to create this are:

```
# Install feliz template
dotnet new -i Feliz.Template

# create new app
dotnet new feliz -n fable-aws-amplify
npm install
# npm audit fix
npm start

# add feliz router
dotnet add .\src\App.fsproj package Feliz.Router

# init amplify project
# npm install -g @aws-amplify/cli
# amplify configure

amplify init

amplify add auth
amplify push

# add code
npm update

# this is a dependency that is not listed in feliz router
dotnet add .\src\App.fsproj package Fable.Browser.Event

npm install aws-amplify
npm install aws-appsync

amplify add api
amplify push
```

Adds files:

```
.graphqlconfig.yml
src/graphql/API.js
src/graphql/mutations.js
src/graphql/queries.js
src/graphql/schema.json
src/graphql/subscriptions.js
```

```
# install snowflaqe
dotnet tool install snowflaqe -g
```

add file:

```
{
 "schema": "src/graphql/schema.json",
 "queries": "src/Data/query",
 "project": "Data",
 "output": "src/Data"
}
```

create src/Data/query folder

```
snowflaqe --generate
```

Changed the codegen config to produce js files

```
npm install graphql-tag
```

Added types to call api in file `types/GraphQL.fs`

```
# tp to read file contents
dotnet add .\src\App.fsproj package FSharp.Data.LiteralProviders
```
