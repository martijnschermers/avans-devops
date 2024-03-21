namespace Domain.BacklogItems.States
{
    public class Todo(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            _backlogItem.ChangeState(new Doing(_backlogItem));
        }

        public override void SetPreviousState()
        {
            throw new InvalidOperationException("To-do has no previous state.");
        }
    }
}