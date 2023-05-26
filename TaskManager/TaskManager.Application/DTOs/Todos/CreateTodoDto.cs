using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Todos
{
    public class CreateTodoDto : BaseEntityDto
    {
        public string Name { get; set; }
        public bool Status { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}