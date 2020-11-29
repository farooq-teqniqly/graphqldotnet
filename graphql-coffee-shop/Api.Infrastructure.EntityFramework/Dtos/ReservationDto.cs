using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Dtos
{
    [Table("Reservation")]
    public class ReservationDto : IReservation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Range(1, 10)]
        public int TotalPeople { get; set; }

        [Required]
        [StringLength(256)]
        public string Email { get; set; }
        public DateTime DateAndTime { get; set; }
    }
}