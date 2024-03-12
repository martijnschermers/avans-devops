using Domain;

namespace SprintStates
{
  public class NotStartedSprintState(Sprint sprint) : SprintState(sprint)
  {
    private readonly Sprint _sprint = sprint;
    
    public override void Edit(string name, DateTime startDate, DateTime endDate)
    {
      _sprint.Name = name;
      _sprint.StartDate = startDate;
      _sprint.EndDate = endDate;
    }
  }
}