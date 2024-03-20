namespace Domain.Sprints.States
{
    public abstract class SprintState(Sprint sprint)
    {
        public Sprint Sprint { get; set; } = sprint;
        public abstract void Edit(string name, DateTime startDate, DateTime endDate);
    }
}