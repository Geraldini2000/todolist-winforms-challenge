using FluentAssertions;
using TodoApp.Domain.Entities;
using Xunit;
using TodoApp.Domain.Entities;

namespace tests.Domain
{
    public class TaskItemTests
    {
        [Fact]
        public void Should_create_task_with_valid_data()
        {
            // Act
            var task = new TaskItem("Test task", "General", 1);

            // Assert
            task.Title.Should().Be("Test task");
            task.Category.Should().Be("General");
            task.UserId.Should().Be(1);
            task.IsCompleted.Should().BeFalse();
            task.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(1));
        }

        [Fact]
        public void Should_complete_task()
        {
            // Arrange
            var task = new TaskItem("Test task", "General", 1);

            // Act
            task.Complete();

            // Assert
            task.IsCompleted.Should().BeTrue();
            task.UpdatedAt.Should().NotBeNull();
        }

        [Fact]
        public void Should_not_change_state_when_completing_already_completed_task()
        {
            // Arrange
            var task = new TaskItem("Test task", "General", 1);
            task.Complete();
            var completedAt = task.UpdatedAt;

            // Act
            task.Complete();

            // Assert
            task.IsCompleted.Should().BeTrue();
            task.UpdatedAt.Should().Be(completedAt);
        }

        [Fact]
        public void Should_update_description()
        {
            // Arrange
            var task = new TaskItem("Test task", "General", 1);

            // Act
            task.UpdateDescription("New description");

            // Assert
            task.Description.Should().Be("New description");
            task.UpdatedAt.Should().NotBeNull();
        }
    }
}
