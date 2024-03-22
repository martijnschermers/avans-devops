using Domain.BacklogItems.States;
using Domain.Forum;
using Domain.Users;

namespace Domain.BacklogItems
{
    public interface IBacklogItem
    {
        string Title { get; }
        string Description { get; }
        bool HasBeenDone { get; set; }
        void AddUser(IUserStrategy user);
        void ChangeState(BacklogItemState state);
        void AddForumReaction(ForumPost forumPost);
    }
}