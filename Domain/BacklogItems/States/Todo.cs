namespace Domain.BacklogItems.States
{
    public class Todo(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.ChangeState(new Doing(backlogItem));
        }

        public override void SetPreviousState()
        {
            throw new InvalidOperationException("To-do has no previous state.");
        }
    }
}