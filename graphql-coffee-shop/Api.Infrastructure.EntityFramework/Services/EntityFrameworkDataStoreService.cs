using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teqniqly.Samples.Graphql.CoffeeShop.Models;

namespace Teqniqly.Samples.Graphql.CoffeeShop.Services
{
    public class EntityFrameworkDataStoreService : IDataStoreService, IDisposable
    {
        private bool _disposed = false;
        private readonly GraphqlDbContext _dbContext;

        public EntityFrameworkDataStoreService(GraphqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<TDto>> QueryAsync<TDto>() where TDto : class, IIdentifiable
        {
            return _dbContext.Set<TDto>().AsQueryable();
        }

        public async Task<TDto> FindAsync<TDto>(int id) where TDto : class, IIdentifiable
        {
            return await _dbContext.Set<TDto>().FindAsync(id);
        }
        public async Task<IEnumerable<TDto>> GetAllAsync<TDto>() where TDto : class, IIdentifiable
        {
            return await _dbContext.Set<TDto>().ToListAsync();
        }

        public async Task<TDto> InsertAsync<TDto>(TDto dto) where TDto : class, IIdentifiable
        {
            var inserted = await _dbContext.Set<TDto>().AddAsync(dto);
            await _dbContext.SaveChangesAsync();
            return inserted.Entity;
        }

        public async Task<TDto> UpdateAsync<TDto>(int id, TDto dto) where TDto : class, IIdentifiable
        {
            var current = await FindAsync<TDto>(id);

            if (current == null)
            {
                return null;
            }

            return await PatchDto(current, dto);
        }

        public async Task<TDto> DeleteAsync<TDto>(int id) where TDto : class, IIdentifiable
        {
            var dtoToRemove = await FindAsync<TDto>(id);

            if (dtoToRemove == null)
            {
                return null;
            }

            var removed = _dbContext.Remove(dtoToRemove);
            await _dbContext.SaveChangesAsync();
            return removed.Entity;
        }

        private async  Task<TDto> PatchDto<TDto>(TDto current, TDto updated) where TDto : class, IIdentifiable
        {
            var patchableProperties = typeof(TDto)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(pi => pi.Name.ToLower() != "id");

            var replaced = current;

            foreach (var property in patchableProperties)
            {
                var updatedPropertyInfo = updated.GetType().GetProperty(property.Name);

                if (updatedPropertyInfo == null)
                {
                    continue;
                }

                var updatedPropertyValue  = property.GetValue(updated);
                property.SetValue(replaced, updatedPropertyValue);
            }

            var patchedDto = _dbContext.Update(replaced);
            await _dbContext.SaveChangesAsync();

            return patchedDto.Entity;
        }

        public void Dispose() => Dispose(true);

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
