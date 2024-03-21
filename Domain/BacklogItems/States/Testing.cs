namespace Domain.BacklogItems.States
{
    public class Testing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            _backlogItem.ChangeState(new Tested(_backlogItem));
        }

        public override void SetPreviousState()
        {
            _backlogItem.ChangeState(new ReadyForTesting(_backlogItem));
        }
    }
}