using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Todos
{
    public class UpdateTodoDto : BaseEntityDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}