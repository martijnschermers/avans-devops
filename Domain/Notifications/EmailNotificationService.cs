using Domain.Users;

namespace Domain.Notifications
{
  public class EmailNotificationService : INotificationService
  {
    private readonly List<User> _users = [];

    public void Attach(User user)
    {
      _users.Add(user);
    }

    public void Detach(User user)
    {
      _users.Remove(user);
    }

    public List<User> GetSubscribers()
    {
      return _users;
    }

    public void Notify(User user, string notification)
    {
      // Send an email to the user
      user.Update(notification);
    }

    public void NotifyAll(string notification)
    {
      foreach (var user in _users)
      {
        // Send an email to the user
        user.Update(notification);
      }
    }
  }
}
