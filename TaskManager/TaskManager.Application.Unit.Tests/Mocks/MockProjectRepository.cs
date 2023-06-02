using Moq;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Domain;

namespace TaskManager.Application.Unit.Tests.Mocks
{
    public class MockProjectRepository
    {
        public static Mock<IProjectRepository> GetProjectRepository()
        {
            var projects = new List<Project>
            {
                new Project
                {
                    Id = 1,
                    Name = "FirstTestProject",
                    Todos = new List<Todo>
                    {
                        new Todo
                        {
                            Id = 1,
                            Name = "First",
                            StartDate = new DateTime(2023, 5, 27),
                            EndDate = new DateTime(2023, 5, 28),
                            Status = false,
                            ProjectId = 1
                        }
                    }
                },
                new Project
                {
                    Id = 2,
                    Name = "SecondTestProject"
                }
            };

            var mockRepo = new Mock<IProjectRepository>();

            mockRepo.Setup(m => m.GetProjectsWithDetails()).ReturnsAsync(projects);

            mockRepo.Setup(m => m.GetProjectWithDetails(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return projects.Where(x => x.Id == id).FirstOrDefault();
            });

            mockRepo.Setup(m => m.AddAsync(It.IsAny<Project>())).ReturnsAsync((Project project) =>
            {
                projects.Add(project);
                return project;
            });

            mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Project>()));

            mockRepo.Setup(m => m.DeleteAsync(It.IsAny<Project>()));

            return mockRepo;
        }
    }
}