using TaskManager.Application.DTOs.Common;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.TodoLists
{
    public class UpdateTodoListDto : BaseEntityDto
    {
        public string Name { get; set; }
        public Todo[]? Todo { get; set; }
    }
}