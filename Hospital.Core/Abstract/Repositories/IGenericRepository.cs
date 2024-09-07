using System.Linq.Expressions;

namespace Hospital.Core.Abstract.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> GetEntityByIdAsync(int id, CancellationToken token);

        T AddEntity(T entity);

        Task<T> DeleteEntityById(int id);

        T UpdateEntity(T entity);

        IQueryable<T> GetAllEntities();

        Task<IEnumerable<T>> ToListAsync(CancellationToken token);

        IQueryable<T> FindEntitiesByCondition(Expression<Func<T, bool>> conditionExpression);

        IQueryable<T> SortEntitiesByCriteria<V>(Expression<Func<T, V>> sortingExpression);
    }
}
