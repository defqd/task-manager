using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Projects.Handlers.Commands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, BaseCommandResponse>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var project = await _projectRepository.GetProjectWithDetails(request.Id);

            if(project is null)
            {
                response.Success = false;
                response.Message = $"Project deletion failed. Missing Project with ID {request.Id}";
                return response;
            }

            await _projectRepository.DeleteAsync(project);

            response.Message = "Project deletion successful.";

            return response;
        }
    }
}