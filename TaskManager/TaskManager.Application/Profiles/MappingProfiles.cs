using AutoMapper;
using TaskManager.Domain;
using TaskManager.Application.DTOs.TodoLists;
using TaskManager.Application.DTOs.Todos;

namespace TaskManager.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<TodoList, TodoListDto>().ReverseMap();
        }
    }
}