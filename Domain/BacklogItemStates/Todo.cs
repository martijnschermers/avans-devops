using Domain;

namespace BacklogItemStates
{
  public class Todo(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
  {
  }
}