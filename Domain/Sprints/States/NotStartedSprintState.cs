namespace Domain.Sprints.States
{
    public class NotStartedSprintState(Sprint sprint) : SprintState(sprint)
    {
        public override void Edit(string name, DateTime startDate, DateTime endDate)
        {
            Sprint.Name = name;
            Sprint.StartDate = startDate;
            Sprint.EndDate = endDate;
        }
    }
}