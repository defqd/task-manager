using FluentValidation;
using TaskManager.Application.Contracts.Persistence;

namespace TaskManager.Application.DTOs.Todos.Validators
{
    public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
    {
        private IProjectRepository _projectRepository;
        public CreateTodoDtoValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than {ComparisonValue}")
                .MustAsync(ProjectMustExist).WithMessage("{PropertyName} does not exist.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(x => x.StartDate)
               .LessThan(x => x.EndDate).WithMessage("{PropertyName} must be before {ComparisonValue}");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");
        }

        private async Task<bool>ProjectMustExist(int id, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectWithDetails(id);
            return project != null;
        }
    }
}