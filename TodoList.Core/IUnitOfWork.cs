using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.IRepositories;

namespace TodoList.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository Tasks { get; }
        ITaskStateRepository TaskStates { get; }
        ITaskCategoryRepository TaskCategories { get; }
        void Complete();
    }
}
