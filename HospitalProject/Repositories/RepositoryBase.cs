using HospitalProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalProject.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        private readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }



        public async Task<IEnumerable<T>> FindAllAsync(bool trackChanges)
        {
            return trackChanges
                ? await _context.Set<T>().ToListAsync()
                : await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges
                ? await _context.Set<T>().Where(expression).ToListAsync()
                : await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

    }
}
