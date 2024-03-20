using Domain.Notifications;

namespace Domain.Sprints.Factory
{
  public abstract class SprintFactory
  {
    public abstract Sprint CreateSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService);
  }
}