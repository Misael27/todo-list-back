using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Application.ValidationHandle.Exceptions;
using TodoList.Core;

namespace TodoList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.Tasks.FindAll().Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
            if (task == null)
            {
                throw new NotFoundException("Task", request.Id.ToString());
            }
            await _unitOfWork.Tasks.RemoveAsync(task);
            _unitOfWork.Complete();
            return Unit.Value;
        }

    }
}
