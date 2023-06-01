using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects.Validators;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Application.Responses;
using TaskManager.Domain;

namespace TaskManager.Application.Features.Projects.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, BaseCommandResponse>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateProjectDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Project creation failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var project = _mapper.Map<Project>(request.CreateProjectDto);
            await _projectRepository.AddAsync(project);

            response.Id = project.Id;
            response.Message = "Project creation successful.";

            return response;
        }
    }
}