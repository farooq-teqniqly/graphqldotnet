using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Dtos
{
    [Table("Menu")]
    public class MenuDto : IMenu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Image { get; set; }
        public ICollection<ISubMenu> SubMenus { get; set; }
    }
}
