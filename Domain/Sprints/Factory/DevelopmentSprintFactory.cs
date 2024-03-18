namespace Domain.Sprints.Factory
{
  public class DevelopmentSprintFactory : SprintFactory
  {
    public override Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
      return new DevelopmentSprint(name, startDate, endDate);
    }
  }
}