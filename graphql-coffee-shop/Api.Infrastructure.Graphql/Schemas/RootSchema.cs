using System;
using GraphQL.Types;
using GraphQL.Utilities;
using Teqniqly.Samples.Graphql.CoffeeShop.Mutations;
using Teqniqly.Samples.Graphql.CoffeeShop.Queries;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<RootQuery>();
            Mutation = serviceProvider.GetRequiredService<RootMutation>();
        }
    }
}
