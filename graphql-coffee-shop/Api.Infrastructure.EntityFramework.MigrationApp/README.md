#Migrations Readme

## Creating a migration

1. Open a terminal window.
2. Go to the solution folder.
3. Run ```dotnet ef migrations add {Migration name} -p Api.Infrastructure.EntityFramework -s Api.Infrastructure.EntityFramework.MigrationApp --context Teqniqly.Samples.Graphql.CoffeeShop.GraphqlDbContext```

## Updating the database

Run ```dotnet ef database  update -p Api.Infrastructure.EntityFramework -s Api.Infrastructure.EntityFramework.MigrationApp --context Teqniqly.Samples.Graphql.CoffeeShop.GraphqlDbContext```

## Removing the last migration

Run ```dotnet ef migrations remove -p Api.Infrastructure.EntityFramework -s Api.Infrastructure.EntityFramework.MigrationApp --context Teqniqly.Samples.Graphql.CoffeeShop.GraphqlDbContext```