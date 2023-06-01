using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public List<Todo>? Todo { get; set; }
    }
}