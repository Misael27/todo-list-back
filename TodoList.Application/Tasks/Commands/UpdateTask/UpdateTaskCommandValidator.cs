using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Application.Tasks.Commands.CreateTask;

namespace TodoList.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Text).NotEmpty().NotNull();
            RuleFor(x => x.date).NotNull();
            RuleFor(x => x.TaskCategoryId).NotNull();
        }
    }
}
