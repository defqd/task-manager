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
                StartDate = new DateTime(2023, 5, 27),
                EndDate = new DateTime(2023, 5, 28),
                Status = false,
                ProjectId = 1
            },
            new Todo
            {
                Id = 2,
                Name = "Second",
                StartDate = new DateTime(2023, 5, 27),
                EndDate = new DateTime(2023, 5, 28),
                Status = false,
                ProjectId = 1
            },
            new Todo
            {
                Id = 3,
                Name = "Third",
                StartDate = new DateTime(2023, 5, 27),
                EndDate = new DateTime(2023, 5, 28),
                Status = false,
                ProjectId = 2
            }
            );
        }
    }
}