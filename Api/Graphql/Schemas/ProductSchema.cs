using GraphQL.Types;
using Teqniqly.Samples.Graphql.Graphql.Mutations;
using Teqniqly.Samples.Graphql.Graphql.Queries;

namespace Teqniqly.Samples.Graphql.Graphql.Schemas
{
    public class ProductSchema : Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
