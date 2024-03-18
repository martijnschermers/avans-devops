using Domain.BacklogItems;
using Domain.Sprints;
using Domain.Users;

namespace Domain.Tests
{
    public class UnitTest1
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

        [Fact]
        public void BacklogItemCanBeAddedToOneSprintOnly()
        {
            // Arrange
            var sprint1 = new DevelopmentSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14));
            var sprint2 = new DevelopmentSprint("Sprint 2", DateTime.Now.AddDays(21), DateTime.Now.AddDays(35));
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, null);

            // Act
            sprint1.AddBacklogItem(backlogItem);
            sprint2.AddBacklogItem(backlogItem);

            // Assert
            Assert.Single(sprint1.BacklogItems);
            Assert.Empty(sprint2.BacklogItems);
        }

        [Fact]
        public void BacklogItemCanHaveOnlyOneDeveloper()
        {
            // Arrange
            var user1 = new Developer("John Doe", "john@gmail.com");
            var user2 = new Developer("Jane Doe", "jane@gmail.com");

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, user1);

            // Act
            backlogItem.AddUser(user2);

            // Assert
            Assert.Equal(user1, backlogItem.User);
        }
    }
}