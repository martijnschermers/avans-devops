namespace Domain.Sprints.States
{
    public abstract class SprintState(Sprint sprint)
    {
        public abstract void Edit(string name, DateTime startDate, DateTime endDate);
    }
}