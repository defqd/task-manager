using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.Features.Todos.Requests.Commands;
using TaskManager.Domain;

namespace TaskManager.Application.Features.Todos.Handlers.Commands
{
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Unit>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public UpdateTodoCommandHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.Get(request.UpdateTodoDto.Id);

            _mapper.Map(request.UpdateTodoDto, todo);

            await _todoRepository.Update(todo);

            return Unit.Value;
        }
    }
}