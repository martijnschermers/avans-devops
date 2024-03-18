using BacklogItemStates;
using Users;

namespace Domain
{
  public class BacklogItemTask : IBacklogItem
  {
    public string Title { get; }
    public string Description { get; }
    public User? User { get; set; }
    public BacklogItem? BacklogItem { get; set; }

    private BacklogItemState _state;

    public BacklogItemTask(string title, string description, User? user = null)
    {
      Title = title;
      Description = description;
      User = user;
      _state = new Todo(this);
    }

    public void AddUser(User user)
    {
      if (User != null)
      {
        return;
      }

      User = user;
    }

    public void ChangeState(BacklogItemState state)
    {
      _state = state;
    }
  }
}