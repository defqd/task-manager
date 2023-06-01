using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Application.Responses;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand, BaseCommandResponse>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var todo = await _todoRepository.GetAsync(request.Id);

            if(todo is null)
            {
                response.Success = false;
                response.Message = $"Todo deletion failed. Missing Todo with ID {request.Id}";
                return response;
            }

            await _todoRepository.DeleteAsync(todo);

            response.Message = "Todo deletion successful.";

            return response;
        }
    }
}