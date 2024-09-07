using Hospital.Core.Abstract.Repositories;
using Hospital.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Hospital.DataAccess.Implementations.Repositories.EF
{
    public class EFGenericRepository<T> : IGenericRepository<T> where T : class
    {
        private HospitalDbContext _context;

        public EFGenericRepository(HospitalDbContext context) => _context = context;

        public T AddEntity(T entity)
        {
            var result = _context.Set<T>().Add(entity);
            return result.Entity;
        }

        public IQueryable<T> FindEntitiesByCondition(Expression<Func<T, bool>> conditionExpression)
        {
            var result = _context.Set<T>().Where(conditionExpression).AsNoTracking();
            return result;
        }

        public IQueryable<T> GetAllEntities()
        {
            var result = _context.Set<T>().AsNoTracking();
            return result;
        }

        public async Task<IEnumerable<T>> ToListAsync(CancellationToken token)
        {
            var result = await _context.Set<T>().ToListAsync(token);
            return result;
        }

        public async Task<T> GetEntityByIdAsync(int id, CancellationToken token)
            => await _context.Set<T>().FindAsync(id, token);

        public async Task<T> DeleteEntityById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);

            return entity;
        }

        public IQueryable<T> SortEntitiesByCriteria<V>(Expression<Func<T, V>> sortingExpression)
            => _context.Set<T>().OrderBy(sortingExpression).AsNoTracking();

        public T UpdateEntity(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
