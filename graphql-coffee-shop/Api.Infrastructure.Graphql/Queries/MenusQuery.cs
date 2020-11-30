using System.Linq;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;
using Teqniqly.Samples.Graphql.CoffeeShop.Types;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Queries
{
    public class MenusQuery : ObjectGraphType
    {
        public MenusQuery(IMenuService menuService)
        {
            FieldAsync<ListGraphType<MenuSummaryType>>(
                "menus",
                resolve: async context =>
                {
                    var result = (await menuService.GetMenusAsync()).ToArray();
                    return result;
                });
        }
    }
}
