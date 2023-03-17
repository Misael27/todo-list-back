using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoList.Core;
using TodoList.Core.Entities;

namespace TodoList.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<TaskCategory>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<TaskCategory>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _unitOfWork.TaskCategories.FindAll().ToListAsync(cancellationToken);
        }
   
    }

}
