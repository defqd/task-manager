using TaskManager.Domain;
using TaskManager.Application.DTOs.Common;

namespace TaskManager.Application.DTOs.Projects
{
    public class CreateProjectDto : BaseEntityDto
    {
        public string Name { get; set; }
        public Todo[]? Todo { get; set; }
    }
}