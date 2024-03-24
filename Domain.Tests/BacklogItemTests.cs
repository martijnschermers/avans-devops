using Domain.BacklogItems;
using Domain.BacklogItems.States;
using Domain.Forum;
using Domain.Notifications;
using Domain.Sprints.Factory;
using Domain.Users.Strategies;
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
            var task1 = new BacklogItemTask("Task 1", "Do something", notificationService, user);
            var task2 = new BacklogItemTask("Task 2", "Do something else", notificationService, user);

            // Act
            backlogItem.AddTask(task1);
            backlogItem.AddTask(task2);

            // Assert
            Assert.Equal(2, backlogItem.Tasks.Count);
        }

        [Fact]
        public void BacklogItemCanOnlyBeMarkedAsDoneWhenAllTasksAreDone()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var user = new Developer("John Doe", "john@gmail.com");
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            var task1 = new BacklogItemTask("Task 1", "Do something", notificationService, user);
            var task2 = new BacklogItemTask("Task 2", "Do something else", notificationService, user);

            backlogItem.AddTask(task1);
            backlogItem.AddTask(task2);

            // Act
            task1.ChangeState(new Done(task1));
            task2.ChangeState(new Doing(task2));

            // Assert
            Assert.IsType<Todo>(backlogItem.State);
        }

        [Fact]
        public void BacklogItemCantBeSetBackToDoingState()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            notificationService.GetSubscribers().Returns([]);
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

            // Act
            backlogItem.NextState();
            backlogItem.NextState();
            backlogItem.NextState();
            backlogItem.NextState();
            backlogItem.NextState();

            backlogItem.PreviousState();
            backlogItem.PreviousState();
            backlogItem.PreviousState();
            backlogItem.PreviousState();

            // Assert
            Assert.IsType<ReadyForTesting>(backlogItem.State);
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
            backlogItem.NextState();
            backlogItem.NextState();
            backlogItem.NextState();

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
            backlogItem.NextState();
            backlogItem.PreviousState();

            // Assert
            notificationService.Received().Notify(scrumMaster, "New feature has been sent back to to-do from testing");
        }

        [Fact]
        public void WhenBacklogItemIsDoneTheForumIsClosedForReactions()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            var forumThread = new ForumThread("Discussion", notificationService);
            var forumPost = new ForumPost("This is a post", "This is the body of the post");

            backlogItem.AddForumThread(forumThread);

            // Act
            backlogItem.ChangeState(new Done(backlogItem));

            // Assert
            Assert.Throws<InvalidOperationException>(() => backlogItem.AddForumReaction(forumPost));
        }

        [Fact]
        public void AddForumReactionToForumThread()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            var forumThread = new ForumThread("Discussion", notificationService);
            var forumPost = new ForumPost("This is a post", "This is the body of the post");

            backlogItem.AddForumThread(forumThread);

            // Act
            forumThread.AddPost(forumPost);

            // Assert
            Assert.Single(forumThread.Posts);
        }

        [Fact]
        public void CantAddUserToBacklogItemTaskIfThereIsAlreadyAUser()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var user1 = new Developer("John Doe", "john@gmail.com");
            var user2 = new Developer("Jane Doe", "jane@gmail.com");
            var task = new BacklogItemTask("Task 1", "Do something", notificationService, user1);

            // Act
            task.AddUser(user2);

            // Assert
            Assert.Equal(user1, task.User);
        }
    }
}