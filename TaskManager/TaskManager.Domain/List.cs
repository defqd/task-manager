using TaskManager.Domain.Common;

namespace TaskManager.Domain
{
    public class List : BaseEntity
    {
        public string Name { get; set; }
        public int TodoId { get; set; }
        public Todo? Todo { get; set; }
    }
}