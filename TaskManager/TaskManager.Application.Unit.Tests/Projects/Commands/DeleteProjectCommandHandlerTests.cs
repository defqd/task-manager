using AutoMapper;
using Moq;
using Shouldly;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Projects.Handlers.Commands;
using TaskManager.Application.Features.Projects.Requests.Commands;
using TaskManager.Application.Profiles;
using TaskManager.Application.Responses;
using TaskManager.Application.Unit.Tests.Mocks;

namespace TaskManager.Application.Unit.Tests.Projects.Commands
{
    public class DeleteProjectCommandHandlerTests
    {
        private readonly Mock<IProjectRepository> _mockRepo;
        private IMapper _mapper;
        private int _projectId = 1;

        public DeleteProjectCommandHandlerTests()
        {
            _mockRepo = MockProjectRepository.GetProjectRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Valid_Project_Delete()
        {
            var handler = new DeleteProjectCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteProjectCommand { Id = _projectId }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task InValid_Project_Delete()
        {
            _projectId = -1;

            var handler = new DeleteProjectCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteProjectCommand { Id = _projectId }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
        }
    }
}