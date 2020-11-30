using System.Collections.Generic;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop
{
    public class MenuModel : IMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<ISubMenu> SubMenus { get; set; }
    }
}
