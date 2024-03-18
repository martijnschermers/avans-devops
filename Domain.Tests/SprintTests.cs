using Domain.Sprints;

namespace Domain.Tests
{
    public class SprintTests
    {
        [Fact]
        public void CannotEditSprintWhenSprintIsStarted()
        {
            // Arrange
            var sprint = new DevelopmentSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.Start();

            // Act
            var exception = Record.Exception(() => sprint.Edit("New name", DateTime.Now, DateTime.Now.AddDays(21)));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}