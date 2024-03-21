using Domain.Forum;

namespace Domain.BacklogItems.States
{
    public abstract class BacklogItemState(IBacklogItem backlogItem)
    {
        public IBacklogItem currentBacklogItem = backlogItem;
        public virtual void AddForumReaction(ForumThread forumThread, ForumPost forumPost)
        {
            forumThread.AddPost(forumPost);
        }

        public abstract void SetNextState();

        public abstract void SetPreviousState();
    }
}