using Domain.BacklogItems;
using Domain.Sprints.Factory;
using Domain.Users;

namespace Domain.Tests
{
    public class BacklogItemTests
    {

        [Fact]
        public void BacklogItemCanBeAddedToOneSprintOnly()
        {
            // Arrange
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint1 = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14));
            var sprint2 = sprintFactory.CreateSprint("Sprint 2", DateTime.Now.AddDays(21), DateTime.Now.AddDays(35));
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