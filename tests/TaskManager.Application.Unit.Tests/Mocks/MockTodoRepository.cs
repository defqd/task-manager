using Moq;
using TaskManager.Application.Contracts.Persistence;
using TaskManager.Domain;

namespace TaskManager.Application.Unit.Tests.Mocks
{
    public class MockTodoRepository
    {
        public static Mock<ITodoRepository> GetTodoRepository()
        {
            var todos = new List<Todo>
            {
                new Todo
                {
                    Id = 1,
                    Name = "FirstTest",
                    StartDate = new DateTime(2023, 5, 27),
                    EndDate = new DateTime(2023, 5, 28),
                    Status = false
                },
                new Todo
                {
                    Id = 2,
                    Name = "SecondTest",
                    StartDate = new DateTime(2023, 5, 27),
                    EndDate = new DateTime(2023, 5, 28),
                    Status = false
                }
            };

            var mockRepo = new Mock<ITodoRepository>();

            mockRepo.Setup(m => m.GetAllAsync()).ReturnsAsync(todos);

            mockRepo.Setup(m => m.GetAsync(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return todos.Where(x => x.Id == id).FirstOrDefault();
            });

            mockRepo.Setup(m => m.AddAsync(It.IsAny<Todo>())).ReturnsAsync((Todo todo) =>
            {
                todos.Add(todo);
                return todo;
            });

            mockRepo.Setup(m => m.UpdateAsync(It.IsAny<Todo>()));

            mockRepo.Setup(m => m.DeleteAsync(It.IsAny<Todo>()));

            return mockRepo;
        }
    }
}