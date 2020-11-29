using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Teqniqly.Samples.Graphql.Services
{
    public class EntityFrameworkDataStoreService : IDataStoreService
    {
        private readonly GraphqlDbContext _dbContext;

        public EntityFrameworkDataStoreService(GraphqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TEntity> FindAsync<TEntity>(int id) where TEntity : class
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>() where TEntity : class
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }


        public async Task<TEntity> InsertAsync<TEntity>(TEntity dto) where TEntity : class
        {
            var inserted = await _dbContext.Set<TEntity>().AddAsync(dto);
            await _dbContext.SaveChangesAsync();
            return inserted.Entity;
        }

        public async Task<TEntity> UpdateAsync<TEntity>(int id, TEntity dto) where TEntity : class
        {
            var entityToUpdate = await FindAsync<TEntity>(id);

            if (entityToUpdate == null)
            {
                return null;
            }

            var dtoPropertyInfos = dto.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi => pi.Name.ToLower() != "id");

            foreach (var dtoPropertyInfo in dtoPropertyInfos)
            {
                var entityToUpdatePropertyInfo = entityToUpdate.GetType().GetProperty(dtoPropertyInfo.Name);
                var dtoPropertyValue = dtoPropertyInfo.GetValue(dto);

                if (dtoPropertyValue != null)
                {
                    entityToUpdatePropertyInfo.SetValue(entityToUpdate, dtoPropertyValue);
                }
            }

            var updatedEntity = _dbContext.Update(entityToUpdate);
            await _dbContext.SaveChangesAsync();

            return updatedEntity.Entity;

        }

        public async Task<TEntity> DeleteAsync<TEntity>(int id) where TEntity : class
        {
            var entityToDelete = await FindAsync<TEntity>(id);

            if (entityToDelete == null)
            {
                return null;
            }

            var deletedEntity = _dbContext.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();

            return deletedEntity.Entity;

        }
    }
}
