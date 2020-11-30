namespace Teqniqly.Samples.Graphql.CoffeeShop.Models
{
    public class SubMenuModel : ISubMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IMenu Menu { get; set; }
    }
}