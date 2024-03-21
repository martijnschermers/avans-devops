namespace Domain.BacklogItems.States
{
    public class ReadyForTesting(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            _backlogItem.ChangeState(new Testing(_backlogItem));
        }

        //previous state check if has been done
        public override void SetPreviousState()
        {
            if (!_backlogItem.HasBeenDone) _backlogItem.ChangeState(new Doing(_backlogItem));
        }
    }
}