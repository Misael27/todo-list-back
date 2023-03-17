using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Tasks;
using TodoList.Application.Tasks.Commands.ChangeState;
using TodoList.Application.Tasks.Commands.CreateTask;
using TodoList.Application.Tasks.Commands.DeleteTask;
using TodoList.Application.Tasks.Commands.UpdateTask;
using TodoList.Application.Tasks.Queries.GetAllTasks;

namespace TodoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private IMediator _mediator;
        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<TaskDto> PostCreateTask(CreateTaskCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("all")]
        public async Task<List<TaskDto>> GetAllTasks()
        {
            return await _mediator.Send(new GetAllTasksQuery());
        }

        [HttpPut("{id:int}")]
        public async Task<TaskDto> PutUpdateTask(int id, UpdateTaskCommand request)
        {
            request.Id = id;
            return await _mediator.Send(request);
        }

        [HttpDelete("{id:int}")]
        public async Task<Unit> DeleteTask(int id)
        {
            return await _mediator.Send(new DeleteTaskCommand(id));
        }

        [HttpPatch("{id:int}/state")]
        public async Task<TaskDto> PatchChangeStateTask(int id)
        {
            return await _mediator.Send(new ChangeStateCommand(id));
        }

    }
}
