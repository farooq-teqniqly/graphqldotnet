using GraphQL.Types;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Types
{
    public sealed class ReservationType : ObjectGraphType<IReservation>
    {
        public ReservationType()
        {
            Field(r => r.Id);
            Field(r => r.Name);
            Field(r => r.Email);
            Field(r => r.Phone);
            Field(r => r.TotalPeople);
            Field(r => r.DateAndTime);
        }
    }
}