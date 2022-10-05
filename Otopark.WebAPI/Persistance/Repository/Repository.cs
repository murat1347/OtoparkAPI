using Microsoft.EntityFrameworkCore;
using Otopark.WebAPI.Core.Application;
using Otopark.WebAPI.Persistance.Context;
using System.Linq.Expressions;

namespace Otopark.WebAPI.Persistance.Repository
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly OtoparkJwtContext _otoparkjwtContext;

        public Repository(OtoparkJwtContext otoparkjwtContext)
        {
            _otoparkjwtContext = otoparkjwtContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _otoparkjwtContext.Set<T>().AddAsync(entity);
            await _otoparkjwtContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _otoparkjwtContext.Set<T>().AsNoTracking().ToListAsync();

        }

        public async Task<T?> GetByFilter(Expression<Func<T, bool>> Filter)
        {
            return await _otoparkjwtContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(Filter);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _otoparkjwtContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _otoparkjwtContext.Set<T>().Remove(entity);
            await _otoparkjwtContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _otoparkjwtContext.Set<T>().Update(entity);
            await _otoparkjwtContext.SaveChangesAsync();
        }
    }
}
