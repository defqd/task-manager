namespace TaskManager.Application.DTOs.Todos
{
    public class TodoDto
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}