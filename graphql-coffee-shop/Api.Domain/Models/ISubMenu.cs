namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public interface ISubMenu : IIdentifiable
    {
        string Name { get; set; }
        string Description { get; set; }
        decimal Price { get; set; }
        IMenu Menu { get; set; }
    }
}