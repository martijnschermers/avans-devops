namespace Domain.BacklogItems.States
{
    public class ReadyForTesting(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
    }
}