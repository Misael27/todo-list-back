using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Core;

namespace TodoList.Application.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTasksQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<TaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.Tasks.FindAll()
                .Select(x => new TaskDto 
                {
                    Id = x.Id,
                    Text = x.Text,
                    Date = x.date,
                    TaskCategory = x.TaskCategory,
                    TaskState = x.TaskState
                })
                .ToListAsync(cancellationToken);
        }
    }
}
