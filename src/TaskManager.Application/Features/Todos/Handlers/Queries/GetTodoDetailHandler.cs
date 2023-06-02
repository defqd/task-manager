using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Features.Todos.Requests.Queries;

namespace TaskManager.Application.Features.Todos.Handlers.Queries
{
    public class GetTodoDetailHandler : IRequestHandler<GetTodoDetailRequest, TodoDto>
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public GetTodoDetailHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }

        public async Task<TodoDto> Handle(GetTodoDetailRequest request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetAsync(request.Id);

            return _mapper.Map<TodoDto>(todo);
        }
    }
}