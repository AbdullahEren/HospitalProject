using System.Linq.Expressions;

namespace HospitalProject.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll(bool trackChanges);
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
