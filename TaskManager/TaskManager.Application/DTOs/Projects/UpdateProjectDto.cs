using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Projects
{
    public class UpdateProjectDto : BaseEntityDto
    {
        public string Name { get; set; }
    }
}