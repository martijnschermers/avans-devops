namespace Domain.BacklogItems.States
{
    public class ReadyForTesting(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.ChangeState(new Testing(backlogItem));
        }
    }
}