using AutoMapper;
using Moq;
using Shouldly;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Features.Projects.Handlers.Commands;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Application.Profiles;
using TaskManager.Application.Responses;
using TaskManager.Application.Unit.Tests.Mocks;

namespace TaskManager.Application.Unit.Tests.Projects.Commands
{
    public class UpdateProjectCommandHandlerTests
    {
        private readonly Mock<IProjectRepository> _mockRepo;
        private IMapper _mapper;
        private readonly UpdateProjectDto _updateProjectDto;

        public UpdateProjectCommandHandlerTests()
        {
            _mockRepo = MockProjectRepository.GetProjectRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ProjectProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _updateProjectDto = new UpdateProjectDto
            {
                Id = 1,
                Name = "FirstRenameTest",
            };
        }

        [Fact]
        public async Task Valid_Project_Update()
        {
            var handler = new UpdateProjectCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateProjectCommand { UpdateProjectDto = _updateProjectDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task InValid_Project_Update()
        {
            _updateProjectDto.Name = "";

            var handler = new UpdateProjectCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateProjectCommand { UpdateProjectDto = _updateProjectDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);
        }
    }
}
