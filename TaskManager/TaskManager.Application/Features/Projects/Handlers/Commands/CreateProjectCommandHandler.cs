using AutoMapper;
using FluentValidation;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects.Validators;
using TaskManager.Application.DTOs.Todos.Validators;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Domain;

namespace TaskManager.Application.Features.Projects.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateProjectDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors);

            var todo = _mapper.Map<Project>(request.CreateProjectDto);

            await _projectRepository.AddAsync(todo);

            return todo.Id;
        }
    }
}