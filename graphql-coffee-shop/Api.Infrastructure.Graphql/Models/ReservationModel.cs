using System;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public class ReservationModel : IReservation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int TotalPeople { get; set; }
        public string Email { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}