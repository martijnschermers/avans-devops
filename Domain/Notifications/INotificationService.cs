using Domain.Users;

namespace Domain.Notifications
{
  public interface INotificationService
  {
    public void Attach(User user);
    public void Detach(User user);
    public List<User> GetSubscribers();
    public void NotifyAll(string notification);
    public void Notify(User user, string notification);
  }
}
