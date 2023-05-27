using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain;

namespace TaskManager.Persistence.Configurations
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todo>
    {
        public void Configure(EntityTypeBuilder<Todo> builder)
        {
            builder.HasData(

            new Todo
            {
                Id = 1,
                Name = "First",
                StartDate = new DateTime(2023, 27, 5),
                EndDate = new DateTime(2023, 28, 5),
                Status = false
            },
            new Todo
            {
                Id = 2,
                Name = "Second",
                StartDate = new DateTime(2023, 27, 5),
                EndDate = new DateTime(2023, 28, 5),
                Status = false
            }
            );
        }
    }
}