using Domain.Users;

namespace Domain.Notifications
{
  public class SlackNotificationService : INotificationService
  {
    private readonly List<IUserStrategy> _users = [];

    public void Attach(IUserStrategy user)
    {
      _users.Add(user);
    }

    public void Detach(IUserStrategy user)
    {
      _users.Remove(user);
    }

    public List<IUserStrategy> GetSubscribers()
    {
      return _users;
    }

    public void Notify(IUserStrategy user, string notification)
    {
      // Send an Slack message to the user
      user.Update(notification);
    }

    public void NotifyAll(string notification)
    {
      foreach (var user in _users)
      {
        // Send an Slack message to the user
        Notify(user, notification);
      }
    }
  }
}
