namespace Domain.BacklogItems.States
{
    public class Doing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.ChangeState(new ReadyForTesting(backlogItem));
        }
    }
}