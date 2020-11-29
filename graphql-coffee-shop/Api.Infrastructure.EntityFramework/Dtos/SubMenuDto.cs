using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Dtos
{
    [Table("SubMenu")]
    public class SubMenuDto : ISubMenu
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(4, 2)")]
        [Range(0.01, 9999.99)]
        public decimal Price { get; set; }
        public IMenu Menu { get; set; }
    }
}