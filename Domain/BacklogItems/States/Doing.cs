namespace Domain.BacklogItems.States
{
    public class Doing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            
            _backlogItem.ChangeState(new ReadyForTesting(_backlogItem));
        }

        public override void SetPreviousState()
        {
            if (_backlogItem.ReadyForTesting) _backlogItem._notificationService.NotifyAll(_backlogItem.Title + " has been sent back to to-do from testing");
            _backlogItem.ReadyForTesting = false;
            _backlogItem.ChangeState(new Todo(_backlogItem));
        }
    }
}