namespace Domain.BacklogItems.States
{
    public class Tested(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.ChangeState(new Done(backlogItem));
        }
    }
}