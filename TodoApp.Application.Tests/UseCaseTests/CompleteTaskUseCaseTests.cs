using FluentAssertions;
using Moq;
using TodoApp.Application.Tasks;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;
using Xunit;

namespace tests.UseCaseTests
{
    public class CompleteTaskUseCaseTests
    {
        [Fact]
        public async Task Should_complete_task_when_task_exists()
        {
            // Arrange
            var task = new TaskItem("Test", "General", 1);

            var repositoryMock = new Mock<ITaskRepository>();
            repositoryMock
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(task);

            var useCase = new CompleteTaskUseCase(repositoryMock.Object);

            // Act
            await useCase.ExecuteAsync(1);

            // Assert
            task.IsCompleted.Should().BeTrue();
            repositoryMock.Verify(r => r.UpdateAsync(task), Times.Once);
        }

        [Fact]
        public async Task Should_throw_exception_when_task_not_found()
        {
            // Arrange
            var repositoryMock = new Mock<ITaskRepository>();
            repositoryMock
                .Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((TaskItem?)null);

            var useCase = new CompleteTaskUseCase(repositoryMock.Object);

            // Act
            var act = async () => await useCase.ExecuteAsync(1);

            // Assert
            await act.Should().ThrowAsync<Exception>();
        }
    }
}
