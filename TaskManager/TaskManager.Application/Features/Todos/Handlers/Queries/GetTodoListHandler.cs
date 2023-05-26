using AutoMapper;
using MediatR;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Application.Features.Todos.Requests.Queries;

namespace TaskManager.Application.Features.Todos.Handlers.Queries
{
    public class GetProjectHandler : IRequestHandler<GetProjectRequest, List<TodoDto>>
    {
        private readonly IProjectRepository _todoListRepository;
        private readonly IMapper _mapper;

        public GetProjectHandler(IProjectRepository todoListRepository, IMapper mapper)
        {
            _todoListRepository = todoListRepository;
            _mapper = mapper;
        }
        public async Task<List<TodoDto>> Handle(GetProjectRequest request, CancellationToken cancellationToken)
        {
            var todoList = await _todoListRepository.GetAll();

            return _mapper.Map<List<TodoDto>>(todoList);
        }
    }
}