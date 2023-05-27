using AutoMapper;
using TaskManager.Application.DTOs.Todos;
using TaskManager.Domain;

namespace TaskManager.Application.Profiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
            CreateMap<CreateTodoDto, Todo>();
            CreateMap<UpdateTodoDto, Todo>();
        }
    }
}