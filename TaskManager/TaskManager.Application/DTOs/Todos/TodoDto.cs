using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Todos
{
    public class TodoDto : BaseEntityDto
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
    }
}