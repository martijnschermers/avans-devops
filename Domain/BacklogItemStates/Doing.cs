using Domain;

namespace BacklogItemStates
{
  public class Doing(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
  {
  }
}