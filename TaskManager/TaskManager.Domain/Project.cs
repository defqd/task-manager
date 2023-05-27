using TaskManager.Domain.Common;

namespace TaskManager.Domain
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public List<Todo>? Todo { get; set; }
    }
}