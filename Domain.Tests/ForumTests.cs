using Domain.Forum;
using Domain.Notifications;
using NSubstitute;

namespace Domain.Tests
{
  public class ForumTests
  {
    [Fact]
    public void CanAddPostToThread()
    {
      // Arrange
      var notificationService = Substitute.For<INotificationService>();
      var thread = new ForumThread("New thread", notificationService);
      var post = new ForumPost("New post", "This is a new post!");

      // Act
      thread.AddPost(post);

      // Assert
      Assert.Single(thread.Posts);
    }

    [Fact]
    public void CanEditPost()
    {
      // Arrange
      var post = new ForumPost("New post", "This is a new post!");

      // Act
      post.EditPost("Edited post", "This is an edited post!");

      // Assert
      Assert.Equal("Edited post", post.Title);
      Assert.Equal("This is an edited post!", post.Body);
    }
  }
}