using AutoMapper;
using Moq;
using Shouldly;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Projects;
using TaskManager.Application.Features.Projects.Handlers.Queries;
using TaskManager.Application.Features.Projects.Requests.Queries;
using TaskManager.Application.Profiles;
using TaskManager.Application.Unit.Tests.Mocks;

namespace TaskManager.Application.Unit.Tests.Projects.Queries
{
    public class GetProjectListHandlerTests
    {
        private readonly Mock<IProjectRepository> _mockRepo;
        private IMapper _mapper;

        public GetProjectListHandlerTests()
        {
            _mockRepo = MockProjectRepository.GetProjectRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<ProjectProfile>();
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetProjectListTest()
        {
            var handler = new GetProjectListHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetProjectListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProjectDto>>();
            result.Count.ShouldBe(2);
        }
    }
}