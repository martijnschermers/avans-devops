using Domain.Users.Strategies;

namespace Domain.BacklogItems.States
{
    public class Doing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            foreach (var user in _backlogItem._notificationService.GetSubscribers())
            {
                if (user.GetType() == typeof(Tester))
                {
                    _backlogItem._notificationService.Notify(user, "The backlog item " + _backlogItem.Title + " is ready for testing");
                }
            }
            _backlogItem.ReadyForTesting = true;
            _backlogItem.ChangeState(new ReadyForTesting(_backlogItem));
        }

        public override void SetPreviousState()
        {
            if (_backlogItem.ReadyForTesting)
            {
                foreach (var user in _backlogItem._notificationService.GetSubscribers())
                {
                    if (user.GetType() == typeof(ScrumMaster))
                    {
                        _backlogItem._notificationService.Notify(user, _backlogItem.Title + " has been sent back to to-do from testing");
                    }
                }
            }
            _backlogItem.ReadyForTesting = false;
            _backlogItem.ChangeState(new Todo(_backlogItem));
        }
    }
}