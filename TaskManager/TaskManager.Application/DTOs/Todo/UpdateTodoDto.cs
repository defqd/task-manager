using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Todo
{
    public class UpdateTodoDto : BaseEntityDto
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}