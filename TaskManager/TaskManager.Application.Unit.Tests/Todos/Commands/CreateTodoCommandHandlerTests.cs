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
    public class CreateTodoCommandHandlerTests
    {
        private readonly Mock<ITodoRepository> _mockRepo;
        private IMapper _mapper;
        private readonly CreateTodoDto _createTodoDto;

        public CreateTodoCommandHandlerTests()
        {
            _mockRepo = MockTodoRepository.GetTodoRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _createTodoDto = new CreateTodoDto
            {
                Name = "CreateTest",
                StartDate = new DateTime(2023, 5, 27),
                EndDate = new DateTime(2023, 5, 28),
                Status = false
            };
        }

        [Fact]
        public async Task Valid_Todo_Added()
        {
            var handler = new CreateTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateTodoCommand { CreateTodoDto = _createTodoDto }, CancellationToken.None);

            var todos = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();

            todos.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_Todo_Added()
        {
            _createTodoDto.Name = "";

            var handler = new CreateTodoCommandHandler(_mockRepo.Object, _mapper);

            var result = await handler.Handle(new CreateTodoCommand { CreateTodoDto = _createTodoDto }, CancellationToken.None);

            var todos = await _mockRepo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);

            todos.Count.ShouldBe(2);
        }
    }
}