using System.Collections.Generic;
using System.Threading.Tasks;
using Teqniqly.Samples.Graphql.Dtos;
using Teqniqly.Samples.Graphql.Models;

namespace Teqniqly.Samples.Graphql.Services
{
    public class ProductService : IProductService
    {
        private readonly IDataStoreService _dataStoreService;

        public ProductService(IDataStoreService dataStoreService)
        {
            _dataStoreService = dataStoreService;
        }

        public async IAsyncEnumerable<IProduct> GetAllProductsAsync()
        {
            var dtos = await _dataStoreService.GetAllAsync<ProductDto>();

            foreach (var dto in dtos)
            {
                yield return new ProductModel
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Price = dto.Price
                };
            }
        }

        public async Task<IProduct> GetProductAsync(int id)
        {
            var dto = await _dataStoreService.FindAsync<ProductDto>(id);

            if (dto == null)
            {
                return  null;
            }

            return new ProductModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price
            };
        }

        public async Task<IProduct> AddProductAsync(IProduct product)
        {
            var dto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price
            };

            var addedProductDto = await _dataStoreService.InsertAsync(dto);

            return new ProductModel
            {
                Id = addedProductDto.Id,
                Name = addedProductDto.Name,
                Price = addedProductDto.Price
            };

        }

        public async Task<IProduct> UpdateProductAsync(int id, IProduct product)
        {
            var productToUpdateDto = await _dataStoreService.FindAsync<ProductDto>(id);

            if (productToUpdateDto == null)
            {
                return null;
            }

            productToUpdateDto = new ProductDto
            {
                Name = product.Name,
                Price = product.Price
            };

            return await _dataStoreService.UpdateAsync(id, productToUpdateDto);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _dataStoreService.DeleteAsync<ProductDto>(id);
        }
    }
}
