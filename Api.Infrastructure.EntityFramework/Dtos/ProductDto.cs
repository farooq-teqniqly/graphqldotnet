using System.ComponentModel.DataAnnotations.Schema;
using Teqniqly.Samples.Graphql.Models;

namespace Teqniqly.Samples.Graphql.Dtos
{
    [Table("product")]
    public class ProductDto : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
