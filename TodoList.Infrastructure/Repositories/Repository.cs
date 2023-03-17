using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoList.Core.IRepositories;

namespace TodoList.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        private readonly DbSet<TEntity> _entity;

        public Repository(DataContext context)
        {
            Context = context;
            _entity = context.Set<TEntity>();
        }

        public TEntity? Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public Task RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public IQueryable<TEntity> FindAll()
        {
            return Context.Set<TEntity>().AsNoTracking();
        }

        public int Count()
        {
            return Context.Set<TEntity>().Count();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity? Get(Guid? id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Set(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

    }
}
