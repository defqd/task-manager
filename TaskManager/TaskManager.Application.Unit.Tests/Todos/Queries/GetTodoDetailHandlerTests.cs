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
    public class GetTodoDetailHandlerTests
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private IMapper _mapper;
        private readonly int _todo = 1;

        public GetTodoDetailHandlerTests()
        {
            _mockRepo = MockTodoRepository.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }
        [Fact]
        public async Task GetTodoDetailTest()
        {
            var handler = new GetTodoDetailHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new GetTodoDetailRequest { Id = _todo }, CancellationToken.None);

            result.ShouldBeOfType<TodoDto>();
        }
    }
}