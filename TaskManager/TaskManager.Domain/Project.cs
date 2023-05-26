using TaskManager.Domain.Common;

namespace TaskManager.Domain
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public Todo[]? Todo { get; set; }
    }
}