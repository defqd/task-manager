using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos.Validators;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, BaseCommandResponse>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var validator = new UpdateTodoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateTodoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Todo update failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var todo = await _todoRepository.GetAsync(request.UpdateTodoDto.Id);

            _mapper.Map(request.UpdateTodoDto, todo);
            await _todoRepository.UpdateAsync(todo);

            response.Message = "Todo updated successfully.";

            return response;
        }
    }
}