using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Todos.Requests.Commands;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public DeleteTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.Get(request.Id);

            await _todoRepository.Delete(todo);

            return Unit.Value;
        }
    }
}