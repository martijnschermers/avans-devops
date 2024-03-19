using Domain.BacklogItems;
using Domain.Notifications;
using Domain.Sprints.Factory;
using Domain.Users;
using NSubstitute;

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

        [Fact]
        public void GeneratedReportContainsCorrectData()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();

            var sprintFactory = new DevelopmentSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14));
            sprint.Start();

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            sprint.AddBacklogItem(backlogItem);
            var user = new Developer("John Doe", "john@gmail.com");
            backlogItem.AddUser(user);

            // Act
            sprint.End();
            var report = sprint.GenerateReport();

            // Assert
            Assert.Contains("Sprint Report", report);
            Assert.Contains("Sprint 1", report);
            Assert.Contains("Sprint went very well", report);
        }
    }
}