using Domain;

namespace BacklogItemStates
{
  public class Tested(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
  {
  }
}