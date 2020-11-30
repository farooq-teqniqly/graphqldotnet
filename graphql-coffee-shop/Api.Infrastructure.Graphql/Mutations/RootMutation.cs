using GraphQL.Types;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Mutations
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation()
        {
            Field<MenuMutation>("menuMutation", resolve: context => new { });
        }
    }
}
