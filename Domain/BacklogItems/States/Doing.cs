namespace Domain.BacklogItems.States
{
    public class Doing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
    }
}