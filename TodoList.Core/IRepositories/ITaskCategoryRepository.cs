using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Core.Entities;

namespace TodoList.Core.IRepositories
{
    public interface ITaskCategoryRepository : IRepository<TaskCategory>
    {
    }
}
