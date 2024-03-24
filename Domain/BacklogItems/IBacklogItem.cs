using Domain.BacklogItems.States;
using Domain.Forum;
using Domain.Notifications;
using Domain.Users;

namespace Domain.BacklogItems
{
    public interface IBacklogItem
    {
        string Title { get; }
        string Description { get; }
        bool HasBeenDone { get; set; }
        bool ReadyForTesting { get; set; }
        INotificationService NotificationService { get; }
        void AddUser(IUserStrategy user);
        void ChangeState(BacklogItemState state);
        void AddForumReaction(ForumPost forumPost);
        bool CheckTasksDone();
    }
}