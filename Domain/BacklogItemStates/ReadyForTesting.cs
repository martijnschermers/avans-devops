using Domain;

namespace BacklogItemStates
{
  public class ReadyForTesting(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
  {
  }
}