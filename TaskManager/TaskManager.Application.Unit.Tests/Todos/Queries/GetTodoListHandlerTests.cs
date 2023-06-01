using AutoMapper;
using Moq;
using Shouldly;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Features.Todos.Handlers.Queries;
using TaskManager.Application.Features.Todos.Requests.Queries;
using TaskManager.Application.Profiles;
using TaskManager.Application.Unit.Tests.Mocks;

namespace TaskManager.Application.Unit.Tests.Todos.Queries
{
    public class GetTodoListHandlerTests
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private IMapper _mapper;

        public GetTodoListHandlerTests()
        {
            _mockRepo = MockTodoRepository.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetTodoListTest()
        {
            var handler = new GetTodoListHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetTodoListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<TodoDto>>();
            result.Count.ShouldBe(2);
        }
    }
}