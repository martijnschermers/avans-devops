using Domain;

namespace BacklogItemStates
{
  public class Done(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
  {
  }
}