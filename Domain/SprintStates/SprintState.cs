using Domain;

namespace SprintStates
{
  public abstract class SprintState(Sprint sprint)
  {
    public abstract void Edit(string name, DateTime startDate, DateTime endDate);
  }
}