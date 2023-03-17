using MediatR;
using TodoList.Core.Entities;

namespace TodoList.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<TaskCategory>>
    {
    }

}
