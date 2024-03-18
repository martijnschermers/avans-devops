namespace Domain.Sprints.Factory
{
  public class ReleaseSprintFactory : SprintFactory
  {
    public override Sprint CreateSprint(string name, DateTime startDate, DateTime endDate)
    {
      return new ReleaseSprint(name, startDate, endDate);
    }
  }
}