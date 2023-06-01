using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class ChangeStatusTodoCommandHandler : IRequestHandler<ChangeStatusTodoCommand, BaseCommandResponse>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public ChangeStatusTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(ChangeStatusTodoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var todo = await _todoRepository.GetAsync(request.ChangeStatusTodoDto.Id);

            if (todo is null)
            {
                response.Success = false;
                response.Message = "Todo change status failed.";
                return response;
            }

            todo.Status = request.ChangeStatusTodoDto.Status;
            await _todoRepository.UpdateAsync(todo);

            response.Message = "Todo status changed.";

            return response;
        }
    }
}