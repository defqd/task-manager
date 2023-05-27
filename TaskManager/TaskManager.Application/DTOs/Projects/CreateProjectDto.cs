using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Projects
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public Todo[]? Todo { get; set; }
    }
}