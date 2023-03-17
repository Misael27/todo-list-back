using TodoList.Core.Entities;
using TodoList.Core.IRepositories;

namespace TodoList.Infrastructure.Repositories
{
    public class TaskCategoryRepository : Repository<TaskCategory>, ITaskCategoryRepository
    {
        public TaskCategoryRepository(DataContext context) : base(context)
        {
        }

        public DataContext? DataContext
        {
            get { return Context as DataContext; }
        }

    }
}
