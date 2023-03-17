using TodoList.Core.IRepositories;

namespace TodoList.Infrastructure.Repositories
{
    public class TaskRepository : Repository<Core.Entities.Task>, ITaskRepository
    {
        public TaskRepository(DataContext context) : base(context)
        {
        }

        public DataContext? DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
