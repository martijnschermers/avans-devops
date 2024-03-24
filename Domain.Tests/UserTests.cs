using Domain.BacklogItems;
using Domain.Notifications;
using Domain.Users.Strategies;

namespace Domain.Tests
{
  public class UserTests
  {
    [Fact]
    public void AssignBacklogItemToDeveloper()
    {
      // Arrange 
      var notificationService = new EmailNotificationService();
      var developer = new Developer("John Doe", "john@gmail.com");
      var backlogItem = new BacklogItem("Implement feature X", "Implement feature X", 12, notificationService);

      // Act
      developer.AssignBacklogItem(backlogItem);

      // Assert
      Assert.Equal(developer, backlogItem.User);
    }

    [Fact]
    public void AssignBacklogItemToTester()
    {
      // Arrange 
      var notificationService = new EmailNotificationService();
      var tester = new Tester("Jane Doe", "jane@gmail.com");
      var backlogItem = new BacklogItem("Implement feature X", "Implement feature X", 12, notificationService);

      // Act
      tester.AssignBacklogItem(backlogItem);

      // Assert
      Assert.Equal(tester, backlogItem.User);
    }

    [Fact]
    public void AssignBacklogItemToProductOwnerIsNotPossible()
    {
      // Arrange 
      var notificationService = new EmailNotificationService();
      var productOwner = new ProductOwner("Jane Doe", "jane@gmail.com");
      var backlogItem = new BacklogItem("Implement feature X", "Implement feature X", 12, notificationService);

      // Act
      productOwner.AssignBacklogItem(backlogItem);

      // Assert
      Assert.Null(backlogItem.User);
    }

    [Fact]
    public void AssignBacklogItemToScrumMasterIsNotPossible()
    {
      // Arrange 
      var notificationService = new EmailNotificationService();
      var scrumMaster = new ScrumMaster("Jane Doe", "jane@gmail.com");
      var backlogItem = new BacklogItem("Implement feature X", "Implement feature X", 12, notificationService);

      // Act
      scrumMaster.AssignBacklogItem(backlogItem);

      // Assert
      Assert.Null(backlogItem.User);
    }
  }
}