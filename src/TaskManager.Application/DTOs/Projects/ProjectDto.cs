using TaskManager.Application.DTOs.Common;
using TaskManager.Application.DTOs.Todos;

namespace TaskManager.Application.DTOs.Projects
{
    public class ProjectDto : BaseEntityDto
    {
        public string Name { get; set; }
        public ICollection<TodoDto> Todos { get; set; } = new List<TodoDto>();
    }
}