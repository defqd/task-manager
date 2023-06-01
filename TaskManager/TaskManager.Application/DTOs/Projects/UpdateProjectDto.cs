using TaskManager.Application.DTOs.Common;
using TaskManager.Domain;

namespace TaskManager.Application.DTOs.Projects
{
    public class UpdateProjectDto : BaseEntityDto
    {
        public string Name { get; set; }
        public List<Todo>? Todo { get; set; }
    }
}