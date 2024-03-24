using Domain.BacklogItems.States;
using Domain.Forum;
using Domain.Notifications;
using Domain.Users;

namespace Domain.BacklogItems
{
    public class BacklogItemTask : IBacklogItem
    {
        public string Title { get; }
        public string Description { get; }
        public IUserStrategy? User { get; set; }
        public BacklogItem? BacklogItem { get; set; }

        public BacklogItemState State { get; set; }
        public INotificationService NotificationService { get; }
        public bool HasBeenDone { get; set; }
        public bool ReadyForTesting { get; set; }


        public BacklogItemTask(string title, string description, INotificationService notificationService, IUserStrategy? user = null)
        {
            Title = title;
            Description = description;
            User = user;
            State = new Todo(this);
            NotificationService = notificationService;
        }

        public void AddUser(IUserStrategy user)
        {
            if (User != null)
            {
                return;
            }

            User = user;
        }

        public void ChangeState(BacklogItemState state)
        {
            State = state;
        }

        public void AddForumReaction(ForumPost forumPost)
        {
            BacklogItem?.AddForumReaction(forumPost);
        }

        public bool CheckTasksDone() { return true; }
    }
}