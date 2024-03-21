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
            _backlogItem.ChangeState(new Todo(_backlogItem));
        }
    }
}