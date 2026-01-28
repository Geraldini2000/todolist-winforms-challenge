using FluentAssertions;
using Moq;
using TodoApp.Application.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;
using Xunit;

namespace tests.UseCaseTests
{
    public class CreateTaskUseCaseTests
    {
        [Fact]
        public async Task Should_create_task_with_valid_data()
        {
            // Arrange
            var repositoryMock = new Mock<ITaskRepository>();
            var useCase = new CreateTaskUseCase(repositoryMock.Object);

            // Act
            await useCase.ExecuteAsync("My Task", "Work", 1);

            // Assert
            repositoryMock.Verify(
                r => r.AddAsync(It.Is<TaskItem>(
                    t => t.Title == "My Task"
                      && t.Category == "Work"
                      && t.UserId == 1
                )),
                Times.Once
            );
        }
    }
}
