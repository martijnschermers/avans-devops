using Domain.Users;

namespace Domain.Notifications
{
  public class EmailNotificationService : INotificationService
  {
    private readonly List<IUserStrategy> _subscribers = [];

    public void Attach(IUserStrategy user)
    {
      _subscribers.Add(user);
    }

    public void Detach(IUserStrategy user)
    {
      _subscribers.Remove(user);
    }

    public List<IUserStrategy> GetSubscribers()
    {
      return _subscribers;
    }

    public void Notify(IUserStrategy user, string notification)
    {
      // Send an email to the user
      user.Update(notification);
    }

    public void NotifyAll(string notification)
    {
      foreach (var subscriber in _subscribers)
      {
        // Send an email to the user
        subscriber.Update(notification);
      }
    }
  }
}
