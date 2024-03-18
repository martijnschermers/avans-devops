using Domain.Sprints.Factory;

namespace Domain.Tests
{
    public class SprintTests
    {
        [Fact]
        public void CannotEditSprintWhenSprintIsStarted()
        {
            // Arrange
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.Start();

            // Act
            var exception = Record.Exception(() => sprint.Edit("New name", DateTime.Now, DateTime.Now.AddDays(21)));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
        }
    }
}