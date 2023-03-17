using TodoList.Core.Entities;
using TodoList.Core.IRepositories;

namespace TodoList.Infrastructure.Repositories
{
    public class TaskStateRepository : Repository<TaskState>, ITaskStateRepository
    {
        public TaskStateRepository(DataContext context) : base(context)
        {
        }

        public DataContext? DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
