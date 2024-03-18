namespace Domain.Sprints.States
{
    public class FinishedSprintState(Sprint sprint) : SprintState(sprint)
    {
        public override void Edit(string name, DateTime startDate, DateTime endDate)
        {
            throw new InvalidOperationException("Cannot edit a sprint that is finished");
        }
    }
}