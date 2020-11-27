using System;
using System.Collections.Generic;
using System.Linq;
using Teqniqly.Samples.Graphql.Models;

namespace Teqniqly.Samples.Graphql.Services
{
    public class ProductService : IProductService
    {
        private static readonly Dictionary<int, Product> Store = new Dictionary<int, Product>();

        public IEnumerable<Product> GetAllProducts()
        {
            return Store.Values;
        }

        public Product GetProduct(int id)
        {
            return Store.SingleOrDefault(kvp => kvp.Key == id).Value;
        }

        public Product AddProduct(Product product)
        {
            if (Store.ContainsKey(product.Id))
            {
                throw new InvalidOperationException($"The product with id {product.Id} already exists.");
            }

            Store.Add(product.Id, product);

            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productToUpdate = GetProduct(id);

            if (productToUpdate == null)
            {
                throw new InvalidOperationException($"The product with id {id} was not found.");
            }

            product.Id = id;
            Store[id] = product;

            return product;
        }

        public void DeleteProduct(int id)
        {
            Store.Remove(id);
        }
    }
}
