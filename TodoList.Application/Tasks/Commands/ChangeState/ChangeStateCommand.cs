using MediatR;

namespace TodoList.Application.Tasks.Commands.ChangeState
{
    public class ChangeStateCommand : IRequest<TaskDto>
    {
        public int Id { get; set; }

        public ChangeStateCommand(int id)
        {
            Id = id;
        }

    }
}
