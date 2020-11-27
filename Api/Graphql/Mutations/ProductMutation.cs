using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.Graphql.Types;
using Teqniqly.Samples.Graphql.Models;
using Teqniqly.Samples.Graphql.Services;

namespace Teqniqly.Samples.Graphql.Graphql.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>(
                "createProduct",
                arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context =>
                {
                    try
                    {
                        return productService.AddProduct(context.GetArgument<Product>("product"));
                    }
                    catch (InvalidOperationException ex)
                    {
                        context.Errors.Add(new ExecutionError(ex.Message));
                        return null;
                    }
                    
                });

            Field<ProductType>(
                "updateProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<ProductInputType> { Name = "product" }),
                resolve: context => productService.UpdateProduct(
                    context.GetArgument<int>("id"),
                    context.GetArgument<Product>("product")));

            Field<BooleanGraphType>(
                "deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    productService.DeleteProduct(context.GetArgument<int>("id"));
                    return true;
                });
        }
    }
}
