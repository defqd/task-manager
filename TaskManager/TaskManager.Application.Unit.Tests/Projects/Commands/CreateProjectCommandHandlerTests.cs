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
using TaskManager.Domain;

namespace TaskManager.Application.Unit.Tests.Projects.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        private readonly Mock<IProjectRepository> _mockRepo;
        private IMapper _mapper;
        private readonly CreateProjectDto _createProjectDto;

        public CreateProjectCommandHandlerTests()
        {
            _mockRepo = MockProjectRepository.GetProjectRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<ProjectProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _createProjectDto = new CreateProjectDto
            {
                Name = "CreateTestProject"
            };
        }

        [Fact]
        public async Task Valid_Project_Added()
        {
            var handler = new CreateProjectCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateProjectCommand { CreateProjectDto = _createProjectDto }, CancellationToken.None);

            var project = await _mockRepo.Object.GetProjectsWithDetails();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();

            project.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_Project_Added()
        {
            _createProjectDto.Name = "";

            var handler = new CreateProjectCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateProjectCommand { CreateProjectDto = _createProjectDto }, CancellationToken.None);

            var project = await _mockRepo.Object.GetProjectsWithDetails();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);

            project.Count.ShouldBe(2);
        }
    }

}