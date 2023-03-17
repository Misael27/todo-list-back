using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.ValidationHandle.Exceptions;
using TodoList.Core;

namespace TodoList.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, TaskDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.FindAll().Include(x => x.TaskState).Include(x => x.TaskCategory).Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (task == null)
            {
                throw new NotFoundException("Task", request.Id.ToString());
            }
            if (!_unitOfWork.TaskCategories.FindAll().Any(x => x.Id == request.TaskCategoryId))
            {
                throw new NotFoundException("Category", request.TaskCategoryId.ToString());
            }

            task.Text = request.Text;
            task.date = request.date;
            task.TaskCategoryId = request.TaskCategoryId;
            _unitOfWork.Tasks.Set(task);
            _unitOfWork.Complete();
            return new TaskDto
            {
                Id = task.Id,
                Text = task.Text,
                Date = task.date,
                TaskCategory = task.TaskCategory,
                TaskState = task.TaskState
            };
        }
    }
}
