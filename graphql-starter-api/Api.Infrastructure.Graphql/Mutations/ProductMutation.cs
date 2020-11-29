using System;
using GraphQL;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.Models;
using Teqniqly.Samples.Graphql.Services;
using Teqniqly.Samples.Graphql.Types;

namespace Teqniqly.Samples.Graphql.Mutations
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
                        return productService.AddProductAsync(context.GetArgument<ProductModel>("product")).Result;
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
                resolve: context => productService.UpdateProductAsync(
                    context.GetArgument<int>("id"),
                    context.GetArgument<ProductModel>("product")).Result);

            Field<BooleanGraphType>(
                "deleteProduct",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    productService.DeleteProductAsync(context.GetArgument<int>("id")).Wait();
                    return true;
                });
        }
    }
}
