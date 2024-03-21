namespace Domain.BacklogItems.States
{
    public class ReadyForTesting(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            currentBacklogItem.ChangeState(new Testing(backlogItem));
        }

        //previous state check if has been done
        public override void SetPreviousState()
        {
            if (currentBacklogItem.HasBeenDone == false) currentBacklogItem.ChangeState(new Doing(backlogItem));
        }
    }
}