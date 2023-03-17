using MediatR;

namespace TodoList.Application.Tasks.Queries.GetAllTasks
{
    public class GetAllTasksQuery : IRequest<List<TaskDto>>
    {
    }

}
