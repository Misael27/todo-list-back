using MediatR;
using TodoList.Core;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.ValidationHandle.Exceptions;

namespace TodoList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            if (!_unitOfWork.TaskCategories.FindAll().Any(x => x.Id == request.TaskCategoryId)) 
            {
                throw new NotFoundException("Category", request.TaskCategoryId.ToString());
            }
            var task = new Core.Entities.Task
            {
                Text = request.Text,
                date = request.date,
                TaskCategoryId = request.TaskCategoryId,
                TaskStateId = TaskConstants.ACTIVE_STATE
            };
            await _unitOfWork.Tasks.AddAsync(task);
            _unitOfWork.Complete();
            task = await _unitOfWork.Tasks.FindAll().Include(x => x.TaskState).Include(x => x.TaskCategory).Where(x => x.Id == task.Id).FirstAsync(cancellationToken);
            return new TaskDto { 
                Id = task.Id,
                Text = task.Text,
                Date = task.date,
                TaskCategory = task.TaskCategory,
                TaskState = task.TaskState
            };
        }

    }
}
