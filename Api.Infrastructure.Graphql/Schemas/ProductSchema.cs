using GraphQL.Types;
using Teqniqly.Samples.Graphql.Mutations;
using Teqniqly.Samples.Graphql.Queries;

namespace Teqniqly.Samples.Graphql.Schemas
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
