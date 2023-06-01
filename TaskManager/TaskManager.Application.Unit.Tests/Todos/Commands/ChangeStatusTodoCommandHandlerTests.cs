using AutoMapper;
using Moq;
using Shouldly;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Features.Todos.Handlers.Commands;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Profiles;
using TaskManager.Application.Responses;
using TaskManager.Application.Unit.Tests.Mocks;

namespace TaskManager.Application.Unit.Tests.Todos.Commands
{
    public class ChangeStatusTodoCommandHandlerTests
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private IMapper _mapper;
        private readonly ChangeStatusTodoDto  _changeStatusTodoDto;
        public ChangeStatusTodoCommandHandlerTests()
        {
            _mockRepo = MockTodoRepository.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _changeStatusTodoDto = new ChangeStatusTodoDto
            {
                Id = 1,
                Status = false
            };
        }

        [Fact]
        public async Task Valid_Todo_Update_Status()
        {
            var handler = new ChangeStatusTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new ChangeStatusTodoCommand { ChangeStatusTodoDto = _changeStatusTodoDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }
    }
}