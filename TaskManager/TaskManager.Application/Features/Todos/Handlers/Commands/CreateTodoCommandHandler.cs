using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos.Validators;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Responses;
using TaskManager.Domain;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, BaseCommandResponse>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public CreateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new CreateTodoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTodoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Todo creation failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var todo = _mapper.Map<Todo>(request.CreateTodoDto);
            todo = await _todoRepository.AddAsync(todo);

            response.Id = todo.Id;
            response.Message = "Todo creation successful.";

            return response;
        }
    }
}