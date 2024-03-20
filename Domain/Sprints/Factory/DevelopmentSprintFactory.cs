using Domain.Notifications;

namespace Domain.Sprints.Factory
{
  public class DevelopmentSprintFactory : SprintFactory
  {
    public override Sprint CreateSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService)
    {
      return new DevelopmentSprint(name, startDate, endDate, notificationService);
    }
  }
}