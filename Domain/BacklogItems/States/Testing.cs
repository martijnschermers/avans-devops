namespace Domain.BacklogItems.States
{
    public class Testing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.ChangeState(new Tested(backlogItem));
        }
    }
}