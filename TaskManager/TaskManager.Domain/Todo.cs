using TaskManager.Domain.Common;

namespace TaskManager.Domain
{
    public class Todo : BaseEntity
    {
        public string Name { get; set; }
        public bool Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;
    }
}