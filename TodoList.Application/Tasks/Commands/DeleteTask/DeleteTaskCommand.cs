using MediatR;

namespace TodoList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteTaskCommand(int id)
        {
            Id = id;
        }

    }
}
