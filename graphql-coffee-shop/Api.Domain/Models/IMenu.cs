using System.Collections.Generic;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public interface IMenu : IIdentifiable
    {
        string Name { get; set; }
        string Image { get; set; }

        ICollection<ISubMenu> SubMenus { get; set; }
    }
}
