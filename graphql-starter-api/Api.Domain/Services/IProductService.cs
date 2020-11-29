using System.Collections.Generic;
using System.Threading.Tasks;
using Teqniqly.Samples.Graphql.Models;

namespace Teqniqly.Samples.Graphql.Services
{
    public interface IProductService
    {
        IAsyncEnumerable<IProduct> GetAllProductsAsync();
        Task<IProduct> GetProductAsync(int id);
        Task<IProduct> AddProductAsync(IProduct product);
        Task<IProduct> UpdateProductAsync(int id, IProduct product);
        Task DeleteProductAsync(int id);
    }
}
