using GraphQL;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.Graphql.Types;
using Teqniqly.Samples.Graphql.Services;

namespace Teqniqly.Samples.Graphql.Graphql.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => productService.GetAllProducts());
            
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context => productService.GetProduct(context.GetArgument<int>("id")));
        }
    }
}
