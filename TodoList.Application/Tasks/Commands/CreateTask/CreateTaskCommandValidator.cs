using FluentValidation;

namespace TodoList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Text).NotEmpty().NotNull();
            RuleFor(x => x.date).NotNull();
            RuleFor(x => x.TaskCategoryId).NotNull();
        }
    }
}
