using Domain.BacklogItems;
using Domain.BacklogItems.States;
using Domain.Notifications;
using Domain.Pipeline;
using Domain.Pipeline.Actions;
using Domain.Sprints.Factory;
using Domain.Sprints.Report;
using Domain.Sprints.States;
using Domain.Users.Strategies;
using NSubstitute;

namespace Domain.Tests
{
    public class SprintTests
    {
        [Fact]
        public void CannotEditSprintWhenSprintIsStarted()
        {
            // Arrange
            var notificationService = new EmailNotificationService();
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
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
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
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

        [Fact]
        public void StartReleaseWhenResultsAreSatisfactory()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var sprintFactory = new ReleaseSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            sprint.Start();

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            sprint.AddBacklogItem(backlogItem);
            var user = new Developer("John Doe", "john@gmail.com");
            backlogItem.AddUser(user);
            backlogItem.ChangeState(new Done(backlogItem));

            var pipeline = new DevelopmentPipeline("Release pipeline", 60);
            pipeline.AddPipelineAction(new Build());
            pipeline.AddPipelineAction(new Test());
            sprint.AddDevelopmentPipeline(pipeline);

            var productOwner = new ProductOwner("Alice Doe", "alice@gmail.com");
            sprint.AddTeamMember(productOwner);

            var scrumMaster = new ScrumMaster("Jane Doe", "jane@gmail.com");
            sprint.AddTeamMember(scrumMaster);

            // Act
            sprint.End();

            // Assert
            notificationService.Received().Notify(scrumMaster, "Sprint release succesfull!");
            notificationService.Received().Notify(productOwner, "Sprint release succesfull!");
        }

        [Fact]
        public void CancelSprintWhenResultsAreNotSatisfactory()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var scrumMaster = new ScrumMaster("Jane Doe", "jane@gmail.com");
            var productOwner = new ProductOwner("Alice Doe", "alice@gmail.com");
            notificationService.GetSubscribers().Returns([scrumMaster, productOwner]);

            var sprintFactory = new ReleaseSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            sprint.Start();

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            sprint.AddBacklogItem(backlogItem);
            var user = new Developer("John Doe", "john@gmail.com");
            backlogItem.AddUser(user);

            sprint.AddTeamMember(scrumMaster);

            sprint.AddTeamMember(productOwner);

            // Act
            sprint.End();

            // Assert
            notificationService.Received().Notify(scrumMaster, "Sprint release cancelled!");
            notificationService.Received().Notify(productOwner, "Sprint release cancelled!");
        }

        [Fact]
        public void ThereCanOnlyBeOneScrumMaster()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var sprintFactory = new ReleaseSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            var scrumMaster = new ScrumMaster("Jane Doe", "jane@gmail.com");
            var secondScrumMaster = new ScrumMaster("John Doe", "john@gmail.com");

            // Act
            sprint.AddTeamMember(scrumMaster);
            sprint.AddTeamMember(secondScrumMaster);

            // Assert
            Assert.Single(sprint.TeamMembers);
        }

        [Fact]
        public void RemovingTeamMemberDetachesHimForNotifications()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var sprintFactory = new ReleaseSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            var scrumMaster = new ScrumMaster("Jane Doe", "jane@gmail.com");

            // Act
            sprint.AddTeamMember(scrumMaster);
            sprint.RemoveTeamMember(scrumMaster);

            // Assert
            notificationService.Received().Detach(scrumMaster);
            notificationService.GetSubscribers().Returns([]);
        }

        [Fact]
        public void ExportSprintReport()
        {
            // Arrange
            var notificationService = Substitute.For<INotificationService>();
            var sprintFactory = new ReleaseSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            sprint.Start();

            var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);
            sprint.AddBacklogItem(backlogItem);
            var user = new Developer("John Doe", "john@gmail.com");
            backlogItem.AddUser(user);

            using StringWriter sw = new();
            Console.SetOut(sw);

            // Act
            sprint.End();
            sprint.GenerateReport();
            sprint.ExportReport(ExportOptions.Pdf);

            // Assert
            Assert.Contains("Exporting to PDF", sw.ToString());

            // Reset the console output
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }

        [Fact]
        public void CanEditSprintWhenNotStarted()
        {
            // Arrange
            var notificationService = new EmailNotificationService();
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);

            // Act
            sprint.Edit("New name", DateTime.Now, DateTime.Now.AddDays(21));

            // Assert
            Assert.Equal("New name", sprint.Name);
        }

        [Fact]
        public void CantEditSprintThatIsFinished()
        {
            // Arrange
            var notificationService = new EmailNotificationService();
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(14), notificationService);
            sprint.Start();
            sprint.End();

            // Act
            var exception = Record.Exception(() => sprint.Edit("New name", DateTime.Now, DateTime.Now.AddDays(21)));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<InvalidOperationException>(exception);
        }

        [Fact]
        public void SprintIsFinishedWhenEndDateIsPassed()
        {
            // Arrange
            var notificationService = new EmailNotificationService();
            var sprintFactory = new DevelopmentSprintFactory();
            var sprint = sprintFactory.CreateSprint("Sprint 1", DateTime.Now, DateTime.Now.AddDays(-1), notificationService);

            // Act
            sprint.ChangeState(new InProgressSprintState(sprint));

            // Assert
            Assert.IsType<FinishedSprintState>(sprint.State);
        }
    }
}