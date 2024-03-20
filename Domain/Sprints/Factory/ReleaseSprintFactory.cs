using Domain.Notifications;

namespace Domain.Sprints.Factory
{
  public class ReleaseSprintFactory : SprintFactory
  {
    public override Sprint CreateSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService)
    {
      return new ReleaseSprint(name, startDate, endDate, notificationService);
    }
  }
}