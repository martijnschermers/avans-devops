using BacklogItemStates;
using SCM;
using Users;

namespace Domain
{
  public interface IBacklogItem
  {
    string Title { get; }
    string Description { get; }
    void AddUser(User user);
    void ChangeState(BacklogItemState state);
  }
}