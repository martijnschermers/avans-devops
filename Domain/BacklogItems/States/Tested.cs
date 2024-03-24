using System.Threading.Tasks;

namespace Domain.BacklogItems.States
{
    public class Tested(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void SetNextState()
        {
            // BacklogItem can only be marked as done if all tasks are done
            if (!_backlogItem.CheckTasksDone()) return;

            _backlogItem.HasBeenDone = true;
            _backlogItem.ChangeState(new Done(_backlogItem));
        }

        public override void SetPreviousState()
        {
            _backlogItem.ChangeState(new Testing(_backlogItem));
        }
    }
}