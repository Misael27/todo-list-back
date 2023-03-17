using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.ValidationHandle.Exceptions;
using TodoList.Core;

namespace TodoList.Application.Tasks.Commands.ChangeState
{
    public class ChangeStateCommandHandler : IRequestHandler<ChangeStateCommand, TaskDto>
    {

        private readonly IUnitOfWork _unitOfWork;

        public ChangeStateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaskDto> Handle(ChangeStateCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.FindAll().Include(x => x.TaskState).Include(x => x.TaskCategory).Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (task == null)
            {
                throw new NotFoundException("Task", request.Id.ToString());
            }
            task.TaskStateId = task.TaskStateId == TaskConstants.ACTIVE_STATE ? TaskConstants.COMPLETE_STATE : TaskConstants.ACTIVE_STATE;
            _unitOfWork.Tasks.Set(task);
            _unitOfWork.Complete();
            task.TaskState.Id = task.TaskStateId;
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