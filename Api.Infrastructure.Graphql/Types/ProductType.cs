using GraphQL.Types;
using Teqniqly.Samples.Graphql.Models;

namespace Teqniqly.Samples.Graphql.Types
{
    public sealed class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Price);
        }
    }
}
