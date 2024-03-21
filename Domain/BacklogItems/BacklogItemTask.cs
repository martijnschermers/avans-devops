using Domain.BacklogItems.States;
using Domain.Forum;
using Domain.Users;

namespace Domain.BacklogItems
{
    public class BacklogItemTask : IBacklogItem
    {
        public string Title { get; }
        public string Description { get; }
        public User? User { get; set; }
        public BacklogItem? BacklogItem { get; set; }

        public BacklogItemState State { get; set; }
        public bool HasBeenDone { get; set; }

        public BacklogItemTask(string title, string description, User? user = null)
        {
            Title = title;
            Description = description;
            User = user;
            State = new Todo(this);
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
            State = state;
        }

        public void AddForumReaction(ForumPost forumPost)
        {
            BacklogItem?.AddForumReaction(forumPost);
        }
    }
}