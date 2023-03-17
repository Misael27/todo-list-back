using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Core.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        TEntity? Get(int id);
        IQueryable<TEntity> FindAll();
        IEnumerable<TEntity>? Find(Expression<Func<TEntity, bool>> predicate);
        TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        int Count();
        void Set(TEntity identity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
