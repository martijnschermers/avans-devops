using Domain.Forum;

namespace Domain.BacklogItems.States
{
    public abstract class BacklogItemState(IBacklogItem backlogItem)
    {
        public virtual void AddForumReaction(ForumPost forumPost)
        {
            backlogItem.AddForumReaction(forumPost);    
        }
    }
}