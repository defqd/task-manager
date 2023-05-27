using AutoMapper;
using MediatR;
using FluentValidation;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects.Validators;
using TaskManager.Application.Features.Projects.Requests.Commands;

namespace TaskManager.Application.Features.Projects.Handlers.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly IProjectRepository _projectRepositor;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepositor, IMapper mapper)
        {
            _projectRepositor = projectRepositor;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateProjectDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors);

            var project = await _projectRepositor.GetAsync(request.UpdateProjectDto.Id);

            _mapper.Map(request.UpdateProjectDto, project);

            await _projectRepositor.UpdateAsync(project);

            return Unit.Value;
        }
    }
}