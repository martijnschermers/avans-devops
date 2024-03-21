using Domain.Forum;

namespace Domain.BacklogItems.States
{
    public class Done(IBacklogItem backlogItem) : BacklogItemState(backlogItem)
    {
        public override void AddForumReaction(ForumThread forumThread, ForumPost forumPost)
        {
            throw new InvalidOperationException("Cannot add forum reactions to done backlog items.");
        }

        public override void SetNextState()
        {
            throw new InvalidOperationException("Done has no next state.");
        }

        public override void SetPreviousState()
        {
            currentBacklogItem.ChangeState(new Tested(backlogItem));
        }
    }
}