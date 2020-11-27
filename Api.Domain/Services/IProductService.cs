using System.Collections.Generic;
using Teqniqly.Samples.Graphql.Models;

namespace Teqniqly.Samples.Graphql.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(int id);
        Product AddProduct(Product product);
        Product UpdateProduct(int id, Product product);
        void DeleteProduct(int id);
    }
}
