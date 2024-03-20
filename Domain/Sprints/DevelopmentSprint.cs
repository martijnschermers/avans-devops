using Domain.Sprints.States;

namespace Domain.Sprints
{
    public class DevelopmentSprint(string name, DateTime startDate, DateTime endDate) : Sprint(name, startDate, endDate)
    {
        public override void End()
        {
            ChangeState(new FinishedSprintState(this));
            StartSprintReview();
        }

        public static void StartSprintReview()
        {
            Console.WriteLine("Sprint review started!");
        }
    }
}