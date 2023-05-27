using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
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
            var project = await _projectRepositor.Get(request.UpdateProjectDto.Id);

            _mapper.Map(request.UpdateProjectDto, project);

            await _projectRepositor.Update(project);

            return Unit.Value;
        }
    }
}