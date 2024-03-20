using Domain.BacklogItems.States;
using Domain.Notifications;
using Domain.Sprints.States;
using Domain.Users;

namespace Domain.Sprints
{
    public class ReleaseSprint(string name, DateTime startDate, DateTime endDate, INotificationService notificationService) : Sprint(name, startDate, endDate, notificationService)
    {
        public void CancelRelease()
        {
            foreach (var user in TeamMembers)
            {
                if (user.GetType() == typeof(ScrumMaster) || user.GetType() == typeof(ProductOwner))
                {
                    NotificationService.Notify(user, "Sprint release cancelled!");
                }
            }
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
            // If the results of the sprint are not satisfactory, cancel the release
            if (ResultsAreSatifactory() == false)
            {
                CancelRelease();
                return;
            }

            var result = StartDevelopmentPipeline();
            if (result == false)
            {
                CancelRelease();
                return;
            }

            // Change the state here so the sprint still can't be edited while the pipeline is running 
            ChangeState(new FinishedSprintState(this));

            foreach (var user in TeamMembers)
            {
                if (user.GetType() == typeof(ScrumMaster) || user.GetType() == typeof(ProductOwner))
                {
                    NotificationService.Notify(user, "Sprint release succesfull!");
                }
            }
        }
    }
}