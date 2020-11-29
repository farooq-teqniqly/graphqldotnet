using System;
using System.Collections.Generic;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public interface IMenu
    {
        int Id { get; set; }
        string Name { get; set; }
        string Image { get; set; }

        ICollection<ISubMenu> SubMenus { get; set; }
    }

    public interface ISubMenu
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        IMenu Menu { get; set; }
    }

    public interface IReservation
    {
        int Id { get; set; }
        string Name { get; set; }
        string Phone { get; set; }
        int TotalPeople { get; set; }
        string Email { get; set; }
        DateTime DateAndTime { get; set; }
    }
}
