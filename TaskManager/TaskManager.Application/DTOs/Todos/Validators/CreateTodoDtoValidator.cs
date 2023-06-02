using FluentValidation;
using TaskManager.Application.Contracts.Persistence;

namespace TaskManager.Application.DTOs.Todos.Validators
{
    public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
    {
        private ITodoRepository _todoRepository;
        public CreateTodoDtoValidator(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(async (id, token) =>
                {
                    var projectExists = await _todoRepository.ExistsAsync(id);
                    return !projectExists;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.StartDate)
               .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
        }
    }
}