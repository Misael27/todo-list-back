using TodoList.Core;
using TodoList.Core.IRepositories;
using TodoList.Infrastructure.Repositories;

namespace TodoList.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public ITaskRepository Tasks { get; private set; }
        public ITaskStateRepository TaskStates { get; private set; }
        public ITaskCategoryRepository TaskCategories { get; private set; }


        public UnitOfWork(DataContext context)
        {
            _context = context;
            Tasks = new TaskRepository(_context);
            TaskStates = new TaskStateRepository(_context);
            TaskCategories = new TaskCategoryRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
