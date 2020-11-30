using System.Linq;
using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Types
{
    public sealed class MenuType : ObjectGraphType<IMenu>
    {
        public MenuType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.Image);

            Field<ListGraphType<SubMenuType>>(
                "subMenus",
                resolve: context => context.Source.SubMenus.ToArray());
        }
    }
}