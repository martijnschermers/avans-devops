namespace Domain.BacklogItems.States
{
    public class Tested(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.HasBeenDone = true;
            currentBacklogItem.ChangeState(new Done(backlogItem));
        }

        public override void SetPreviousState()
        {
            currentBacklogItem.ChangeState(new Testing(backlogItem));
        }
    }
}