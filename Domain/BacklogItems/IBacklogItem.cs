using Domain.BacklogItems.States;
using Domain.Users;

namespace Domain.BacklogItems
{
    public interface IBacklogItem
    {
        string Title { get; }
        string Description { get; }
        void AddUser(User user);
        void ChangeState(BacklogItemState state);
    }
}