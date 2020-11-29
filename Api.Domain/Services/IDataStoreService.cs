using System.Collections.Generic;
using System.Threading.Tasks;

namespace Teqniqly.Samples.Graphql.Services
{
    public interface IDataStoreService
    {
        Task<TDto> FindAsync<TDto>(int id) where TDto : class;

        Task<IEnumerable<TDto>> GetAllAsync<TDto>() where TDto : class;

        Task<TDto> InsertAsync<TDto>(TDto dto) where TDto : class;
        Task<TDto> UpdateAsync<TDto>(int id, TDto dto) where TDto : class;
        Task<TDto> DeleteAsync<TDto>(int id) where TDto : class;


    }
}
