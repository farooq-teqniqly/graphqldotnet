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

    public sealed class MenuInputType : InputObjectGraphType<MenuModel>
    {
        public MenuInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("image");
            Field<ListGraphType<SubMenuInputType>>("subMenus");
        }
    }

    public sealed class SubMenuInputType : InputObjectGraphType<SubMenuModel>
    {
        public SubMenuInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<DecimalGraphType>("price");
        }
    }
}