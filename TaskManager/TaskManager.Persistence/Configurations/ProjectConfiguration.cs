using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain;

namespace TaskManager.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasData
            ( 
                new Project
                {
                    Id = 1,
                    Name = "FirstProject"
                },
                new Project
                {
                    Id = 2,
                    Name = "SecondProject"
                }
            );
        }
    }
}