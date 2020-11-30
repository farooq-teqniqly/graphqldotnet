using System.Collections.Generic;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public class MenuModel : IMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<ISubMenu> SubMenus { get; set; }
    }
}
