namespace Domain.BacklogItems.States
{
    public class Done(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
    }
}