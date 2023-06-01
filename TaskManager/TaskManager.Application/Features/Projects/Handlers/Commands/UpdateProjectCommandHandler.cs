using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects.Validators;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Projects.Handlers.Commands
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, BaseCommandResponse>
    {
        private readonly IProjectRepository _projectRepositor;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IProjectRepository projectRepositor, IMapper mapper)
        {
            _projectRepositor = projectRepositor;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateProjectDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateProjectDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Project update failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var project = await _projectRepositor.GetAsync(request.UpdateProjectDto.Id);

            _mapper.Map(request.UpdateProjectDto, project);
            await _projectRepositor.UpdateAsync(project);

            response.Message = "Project updated successfully.";

            return response;
        }
    }
}