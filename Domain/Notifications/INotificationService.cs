using Domain.Users;

namespace Domain.Notifications
{
  public interface INotificationService
  {
    public void Attach(IUserStrategy user);
    public void Detach(IUserStrategy user);
    public List<IUserStrategy> GetSubscribers();
    public void NotifyAll(string notification);
    public void Notify(IUserStrategy user, string notification);
  }
}
