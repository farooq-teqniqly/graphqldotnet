namespace Teqniqly.Samples.Graphql.Models
{
    public interface IProduct
    {
        public int Id { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
