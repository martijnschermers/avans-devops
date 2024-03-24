using Domain.BacklogItems;
using Domain.Notifications;
using NSubstitute;

namespace Domain.Tests
{
  public class ProductBacklogTests
  {
    [Fact]
    public void CanAddBacklogItemToBacklog()
    {
      // Arrange
      var notificationService = Substitute.For<INotificationService>();
      var backlog = new ProductBacklog();
      var backlogItem = new BacklogItem("New feature", "As a user, I want to be able to do something", 5, notificationService);

      // Act
      backlog.AddBacklogItem(backlogItem);

      // Assert
      Assert.Single(backlog.BacklogItems);
    }
  }
}