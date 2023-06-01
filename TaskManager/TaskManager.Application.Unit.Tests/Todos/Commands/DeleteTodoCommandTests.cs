using AutoMapper;
using Moq;
using Shouldly;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Todos.Handlers.Commands;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Profiles;
using TaskManager.Application.Responses;
using TaskManager.Application.Unit.Tests.Mocks;

namespace TaskManager.Application.Unit.Tests.Todos.Commands
{
    public class DeleteTodoCommandTests
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private IMapper _mapper;
        private int _todo = 1;

        public DeleteTodoCommandTests()
        {
            _mockRepo = MockTodoRepository.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Valid_Todo_Delete()
        {
            var handler = new DeleteTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteTodoCommand { Id = _todo }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task InValid_Todo_Delete()
        {
            _todo = -1;

            var handler = new DeleteTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new DeleteTodoCommand { Id = _todo }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
        }
    }
}