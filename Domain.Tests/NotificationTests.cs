using Domain.Notifications;
using Domain.Users.Strategies;
using NSubstitute;

namespace Domain.Tests
{
  public class NotificationTests
  {
    [Fact]
    public void CanNotifySpecificUser()
    {
      // Arrange
      var notificationService = Substitute.For<INotificationService>();
      var user = new Developer("John Doe", "john@gmail.com");

      // Act
      notificationService.Notify(user, "New message");

      // Assert
      notificationService.Received().Notify(user, "New message");
    }

    [Fact]
    public void CanNotifyAllUsersThroughEmail()
    {
      // Arrange
      var notificationService = new EmailNotificationService();
      var user1 = new Developer("John Doe", "john@gmail.com");
      var user2 = new Developer("Jane Doe", "jane@gmail.com");

      notificationService.Attach(user1);
      notificationService.Attach(user2);

      using StringWriter sw = new();
      Console.SetOut(sw);

      // Act
      notificationService.NotifyAll("New message");

      // Assert
      Assert.Contains($"Hey John Doe (john@gmail.com), you've got a new notification: New message", sw.ToString());
      Assert.Contains($"Hey Jane Doe (jane@gmail.com), you've got a new notification: New message", sw.ToString());

      // Reset the console output
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void CanNotifyAllUsersThroughSlack()
    {
      // Arrange
      var notificationService = new SlackNotificationService();
      var user1 = new Developer("John Doe", "john@gmail.com");
      var user2 = new Developer("Jane Doe", "jane@gmail.com");

      notificationService.Attach(user1);
      notificationService.Attach(user2);

      using StringWriter sw = new();
      Console.SetOut(sw);

      // Act
      notificationService.NotifyAll("New message");

      // Assert
      Assert.Contains($"Hey John Doe (john@gmail.com), you've got a new notification: New message", sw.ToString());
      Assert.Contains($"Hey Jane Doe (jane@gmail.com), you've got a new notification: New message", sw.ToString());

      // Reset the console output
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void CanNotifyAllUsers()
    {
      // Arrange
      var notificationService = Substitute.For<INotificationService>();
      var user1 = new Developer("John Doe", "john@gmail.com");
      var user2 = new Developer("Jane Doe", "jane@gmail.com");
      notificationService.GetSubscribers().Returns([user1, user2]);

      // Set up the NotifyAll method to call Notify for each user
      notificationService.When(x => x.NotifyAll(Arg.Any<string>()))
        .Do(x =>
        {
          notificationService.Notify(user1, x.Arg<string>());
          notificationService.Notify(user2, x.Arg<string>());
        });

      notificationService.Attach(user1);
      notificationService.Attach(user2);

      // Act
      notificationService.NotifyAll("New message");

      // Assert
      notificationService.Received().Notify(user1, "New message");
      notificationService.Received().Notify(user2, "New message");
    }
  }
}
