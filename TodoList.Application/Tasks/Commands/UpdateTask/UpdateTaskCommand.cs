using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest<TaskDto>
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime date { get; set; }
        public int TaskCategoryId { get; set; }
    }
}
