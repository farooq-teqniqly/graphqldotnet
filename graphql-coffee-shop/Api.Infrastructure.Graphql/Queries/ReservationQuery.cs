using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Services;
using Teqniqly.Samples.Graphql.CoffeeShop.Types;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Queries
{
    public class ReservationQuery : ObjectGraphType
    {
        public ReservationQuery(IReservationService reservationService)
        {
            FieldAsync<ListGraphType<ReservationType>>(
                "reservations",
                resolve: async context => await reservationService.GetReservationsAsync());
        }
    }
}