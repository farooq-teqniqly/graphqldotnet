using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public interface IDataStoreService
    {
        Task<IQueryable<TDto>> QueryAsync<TDto>() where TDto : class, IIdentifiable;
        Task<TDto> FindAsync<TDto>(int id) where TDto : class, IIdentifiable;
        Task<IEnumerable<TDto>> GetAllAsync<TDto>() where TDto : class, IIdentifiable;

        Task<TDto> InsertAsync<TDto>(TDto dto) where TDto : class, IIdentifiable;
        Task<TDto> UpdateAsync<TDto>(int id, TDto dto) where TDto : class, IIdentifiable;
        Task<TDto> DeleteAsync<TDto>(int id) where TDto : class, IIdentifiable;
    }
}
