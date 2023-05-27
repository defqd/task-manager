using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Features.Projects.Requests.Queries;

namespace TaskManager.Application.Features.Projects.Handlers.Queries
{
    public class GetProjectListHandler : IRequestHandler<GetProjectListRequest, List<ProjectDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetProjectListHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectDto>> Handle(GetProjectListRequest request, CancellationToken cancellationToken)
        {
            var projects = await _projectRepository.GetProjectWithDetails();

            return _mapper.Map<List<ProjectDto>>(projects);
        }
    }
}