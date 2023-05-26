using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Todos
{
    public class ChangeStatusTodoDto : BaseEntityDto
    {
        public bool Status { get; set; }
    }
}