namespace Domain.BacklogItems.States
{
    public class ReadyForTesting(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            _backlogItem.NotificationService.NotifyAll(_backlogItem.Title + " is ready for testing!");
            _backlogItem.ChangeState(new Testing(_backlogItem));
        }

        //Check if it has been in the Done state before
        public override void SetPreviousState()
        {
            if (!_backlogItem.HasBeenDone) _backlogItem.ChangeState(new Doing(_backlogItem));
        }
    }
}