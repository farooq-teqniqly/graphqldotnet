using GraphQL;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;
using Teqniqly.Samples.Graphql.CoffeeShop.Types;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Mutations
{
    public class MenuMutation : ObjectGraphType
    {
        public MenuMutation(IMenuService menuService)
        {
            FieldAsync<MenuType>(
                "createMenu",
                arguments: new QueryArguments(new QueryArgument<MenuInputType> {Name = "menu"}),
                resolve: async context =>
                {
                    var menu = context.GetArgument<MenuType>("menu");
                    return await menuService.AddMenuAsync(context.GetArgument<MenuModel>("menu"));
                });

            FieldAsync<MenuType>(
                "deleteMenu",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => await menuService.DeleteMenuAsync(context.GetArgument<int>("id")));
        }
    }
}
