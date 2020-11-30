using GraphQL;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;
using Teqniqly.Samples.Graphql.CoffeeShop.Types;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Queries
{
    public class MenuQuery : ObjectGraphType
    {
        public MenuQuery(IMenuService menuService)
        {
            FieldAsync<MenuType>(
                "menu",
                arguments:new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var result = await menuService.GetMenuAsync(id);
                    return result;
                });
        }
    }
}