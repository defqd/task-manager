using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Features.Projects.Requests.Queries;

namespace TaskManager.Application.Features.Projects.Handlers.Queries
{
    public class GetProjectDetailHandler : IRequestHandler<GetProjectDetailRequest, ProjectDto>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        public GetProjectDetailHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<ProjectDto> Handle(GetProjectDetailRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.Get(request.Id);

            return _mapper.Map<ProjectDto>(project);
        }
    }
}