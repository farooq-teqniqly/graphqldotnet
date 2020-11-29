namespace Teqniqly.Samples.Graphql.Models
{
    public class ProductModel : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
