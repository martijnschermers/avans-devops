using Domain.BacklogItems;
using Domain.BacklogItems.States;
using Domain.Notifications;
using Domain.Sprints.Factory;
using Domain.Users;
using NSubstitute;

namespace Domain.Tests
{
    public class BacklogItemTests
    {

        [Fact]
        public void BacklogItemCanBeAddedToOneSprintOnly()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint1 = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            var sprint2 = sprintFactory.CreateSprint("Sprint 2", DateTime.Now.AddDays(21), DateTime.Now.AddDays(35), notificationService);
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

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
            var notificationService = Substitute.For<INotificationService>();
            var user1 = new Developer("John Doe", "john@gmail.com");
            var user2 = new Developer("Jane Doe", "jane@gmail.com");

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService, user1);

            // Act
            backlogItem.AddUser(user2);

            // Assert
            Assert.Equal(user1, backlogItem.User);
        }

        [Fact]
        public void BacklogItemCanHaveMultipleTasks()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var user = new Developer("John Doe", "john@gmail.com");
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            var task1 = new BacklogItemTask("Task 1", "Do something", user);
            var task2 = new BacklogItemTask("Task 2", "Do something else", user);

            // Act
            backlogItem.AddTask(task1);
            backlogItem.AddTask(task2);

            // Assert
            Assert.Equal(2, backlogItem.Tasks.Count);
        }

        [Fact]
        public void BacklogItemCantBeSetBackToDoingState()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            notificationService.GetSubscribers().Returns([]);
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

            // Act
            backlogItem.ChangeState(new Done(backlogItem));
            backlogItem.ChangeState(new Doing(backlogItem));

            // Assert
            Assert.IsType<Done>(backlogItem.State);
        }

        [Fact]
        public void TesterGetsNotificationWhenItemIsReadyForTesting()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var tester = new Tester("John Doe", "john@gmail.com");
            notificationService.GetSubscribers().Returns([tester]);

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

            // Act
            backlogItem.ChangeState(new ReadyForTesting(backlogItem));

            // Assert
            notificationService.Received().Notify(tester, "The backlog item New feature is ready for testing");
        }

        [Fact]
        public void OtherUsersThanTestersDontGetNotificationWhenItemIsReadyForTesting()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var developer = new Developer("John Doe", "dev@gmail.com");
            var tester = new Tester("Jane Doe", "tester@gmail.com");
            notificationService.GetSubscribers().Returns([developer, tester]);

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

            // Act
            backlogItem.ChangeState(new ReadyForTesting(backlogItem));

            // Assert
            notificationService.DidNotReceive().Notify(developer, "The backlog item New feature is ready for testing");
        }

        [Fact]
        public void ScrumMasterGetsNotificationWhenItemIsSetBackToTodo()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var scrumMaster = new ScrumMaster("Scum Meester", "scrum@gmail.com");
            notificationService.GetSubscribers().Returns([scrumMaster]);

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

            // Act
            backlogItem.ChangeState(new Doing(backlogItem));
            backlogItem.ChangeState(new Todo(backlogItem));

            // Assert
            notificationService.Received().Notify(scrumMaster, "The backlog item New feature is set back to the todo state");
        }
    }
}