using TaskManager.Domain;

namespace TaskManager.Application.DTOs.TodoLists
{
    public class TodoListDto
    {
        public string Name { get; set; }
        public Todo[]? Todo { get; set; }
    }
}