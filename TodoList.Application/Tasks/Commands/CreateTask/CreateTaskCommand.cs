using MediatR;

namespace TodoList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<TaskDto>
    {
        public string? Text { get; set; }
        public DateTime date { get; set; }
        public int TaskCategoryId { get; set; }
    }
}
