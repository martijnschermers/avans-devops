using Domain.Notifications;

namespace Domain.Forum
{
  public class ForumThread(string topic, INotificationService notificationService)
  {
    public readonly List<ForumPost> Posts = [];
    private readonly INotificationService _notificationService = notificationService;

    public void AddPost(ForumPost post)
    {
      _notificationService.NotifyAll($"New post added to {topic}!");
      Posts.Add(post);
    }
  }
}