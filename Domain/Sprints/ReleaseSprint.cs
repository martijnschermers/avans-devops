using Domain.BacklogItems.States;
using Domain.Sprints.States;

namespace Domain.Sprints
{
    public class ReleaseSprint(string name, DateTime startDate, DateTime endDate) : Sprint(name, startDate, endDate)
    {
        public static void StartRelease()
        {
            Console.WriteLine("Sprint released!");
        }

        public static void CancelRelease()
        {
            
            Console.WriteLine("Sprint release cancelled!");
        }

        public bool ResultsAreSatifactory()
        {
            // Loop over the BacklogItems of the sprint and check if they are all done
            foreach (var backlogItem in BacklogItems)
            {
                if (backlogItem.State is not Done)
                {
                    return false;
                }
            }

            return true;
        }

        public override void End()
        {
            ChangeState(new FinishedSprintState(this));

            // If the results of the sprint are not satisfactory, cancel the release
            if (ResultsAreSatifactory() == false)
            {
                CancelRelease();
                return;
            }

            StartRelease();
        }
    }
}