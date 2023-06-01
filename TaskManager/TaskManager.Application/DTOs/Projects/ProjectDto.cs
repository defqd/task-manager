using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Projects
{
    public class ProjectDto
    {
        public string Name { get; set; }
        public List<Todo>? Todo { get; set; }
    }
}