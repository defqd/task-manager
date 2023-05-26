using TaskManager.Domain;
using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.TodoLists
{
    public class CreateTodoListDto : BaseEntityDto
    {
        public string Name { get; set; }
        public Todo[]? Todo { get; set; }
    }
}