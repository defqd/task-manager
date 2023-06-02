namespace TaskManager.Application.DTOs.Todos
{
    public class CreateTodoDto
    {
        public string Name { get; set; }
        public bool Status { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
    }
}