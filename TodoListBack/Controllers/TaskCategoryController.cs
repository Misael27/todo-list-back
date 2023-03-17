using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoList.Core.Entities;
using TodoList.Application.Categories.Queries.GetAllCategories;

namespace TodoList.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        private IMediator _mediator;
        public TaskCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        public async Task<List<TaskCategory>> GetAllCategories()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }

    }
}
