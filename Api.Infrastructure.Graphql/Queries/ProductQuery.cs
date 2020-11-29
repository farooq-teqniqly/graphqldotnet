using System.Linq;
using GraphQL;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.Services;
using Teqniqly.Samples.Graphql.Types;

namespace Teqniqly.Samples.Graphql.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => productService.GetAllProductsAsync().ToListAsync().Result);
            
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => productService.GetProductAsync(context.GetArgument<int>("id")).Result);
        }
    }
}
