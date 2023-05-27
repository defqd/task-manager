using AutoMapper;
using FluentValidation;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos.Validators;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Domain;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, int>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTodoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTodoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.Errors);

            var todo = _mapper.Map<Todo>(request.CreateTodoDto);

            await _todoRepository.Add(todo);

            return todo.Id;
        }
    }
}