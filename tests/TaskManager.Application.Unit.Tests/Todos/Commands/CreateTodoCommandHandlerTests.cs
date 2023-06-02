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
        private readonly Mock<ITodoRepository> _mockRepoTodo;
        private readonly Mock<IProjectRepository> _mockRepoProject;
        private IMapper _mapper;
        private readonly CreateTodoDto _createTodoDto;

        public CreateTodoCommandHandlerTests()
        {
            _mockRepoTodo = MockTodoRepository.GetTodoRepository();
            _mockRepoProject = MockProjectRepository.GetProjectRepository();

            var mapperConfig = new MapperConfiguration(c => {
                c.AddProfile<TodoProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _createTodoDto = new CreateTodoDto
            {
                Name = "CreateTest",
                StartDate = new DateTime(2023, 5, 27),
                EndDate = new DateTime(2023, 5, 28),
                Status = false,
                ProjectId = 1
            };
        }

        [Fact]
        public async Task Valid_Todo_Added()
        {
            var handler = new CreateTodoCommandHandler(_mockRepoTodo.Object, _mapper, _mockRepoProject.Object);

            var result = await handler.Handle(new CreateTodoCommand { CreateTodoDto = _createTodoDto }, CancellationToken.None);

            var todos = await _mockRepoTodo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeTrue();

            todos.Count.ShouldBe(3);
        }

        [Fact]
        public async Task InValid_Todo_Added()
        {
            _createTodoDto.Name = "";

            var handler = new CreateTodoCommandHandler(_mockRepoTodo.Object, _mapper, _mockRepoProject.Object);

            var result = await handler.Handle(new CreateTodoCommand { CreateTodoDto = _createTodoDto }, CancellationToken.None);

            var todos = await _mockRepoTodo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);

            todos.Count.ShouldBe(2);
        }

        [Fact]
        public async Task InValid_ProjectId_Todo_Added()
        {
            _createTodoDto.ProjectId = -1;

            var handler = new CreateTodoCommandHandler(_mockRepoTodo.Object, _mapper, _mockRepoProject.Object);

            var result = await handler.Handle(new CreateTodoCommand { CreateTodoDto = _createTodoDto }, CancellationToken.None);

            var todos = await _mockRepoTodo.Object.GetAllAsync();

            result.ShouldBeOfType<BaseCommandResponse>();
            result.Success.ShouldBeFalse();
            result.Errors.Count.ShouldBeGreaterThan(0);

            todos.Count.ShouldBe(2);
        }
    }
}