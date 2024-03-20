using Domain.Notifications;

namespace Domain.Forum
{
  public class ForumThread(string topic, INotificationService notificationService)
  {
    private readonly List<ForumPost> _posts = [];
    private readonly INotificationService _notificationService = notificationService;

    public void AddPost(ForumPost post)
    {
      _notificationService.NotifyAll($"New post added to {topic}!");
      _posts.Add(post);
    }

    public void RemovePost(ForumPost post)
    {
      _posts.Remove(post);
    }
  }
}