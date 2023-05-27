using FluentValidation;

namespace TaskManager.Application.DTOs.Todos.Validators
{
    public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
    {
        public CreateTodoDtoValidator()
        {
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