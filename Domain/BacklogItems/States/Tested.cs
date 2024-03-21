namespace Domain.BacklogItems.States
{
    public class Tested(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            _backlogItem.HasBeenDone = true;
            _backlogItem.ChangeState(new Done(_backlogItem));
        }

        public override void SetPreviousState()
        {
            _backlogItem.ChangeState(new Testing(_backlogItem));
        }
    }
}