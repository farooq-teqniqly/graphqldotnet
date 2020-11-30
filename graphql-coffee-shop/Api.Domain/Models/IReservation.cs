using System;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public interface IReservation : IIdentifiable
    {
        string Name { get; set; }
        string Phone { get; set; }
        int TotalPeople { get; set; }
        string Email { get; set; }
        DateTime DateAndTime { get; set; }
    }
}