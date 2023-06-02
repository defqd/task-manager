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
    public class UpdateTodoCommandHandlerTests
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private IMapper _mapper;
        private readonly UpdateTodoDto _updateTodoDto;
        public UpdateTodoCommandHandlerTests()
        {
            _mockRepo = MockTodoRepository.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _updateTodoDto = new UpdateTodoDto 
            {
                Id = 1,
                Name = "FirstRenameTest",
                StartDate = new DateTime(2023, 5, 27),
                EndDate = new DateTime(2023, 5, 28)
            };
        }

        [Fact]
        public async Task Valid_Todo_Update()
        {
            var handler = new UpdateTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateTodoCommand { UpdateTodoDto = _updateTodoDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();
        }

        [Fact]
        public async Task InValid_Todo_Update()
        {
            _updateTodoDto.EndDate = new DateTime(2023, 5, 26);

            var handler = new UpdateTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new UpdateTodoCommand { UpdateTodoDto = _updateTodoDto }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);
        }
    }
}