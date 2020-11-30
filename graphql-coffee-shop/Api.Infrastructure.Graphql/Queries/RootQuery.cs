using GraphQL.Types;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery()
        {
            Field<MenuQuery>("menuQuery", resolve: context => new { });
            Field<MenusQuery>("menusQuery", resolve: context => new { });
            Field<ReservationQuery>("reservationQuery", resolve: context => new { });
        }
    }
}
