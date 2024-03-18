using Domain.Sprints;
using Domain.Forum;
using Domain.Git;
using Domain.Users;
using Domain.BacklogItems.States;

namespace Domain.BacklogItems
{
    public class BacklogItem : IBacklogItem
    {
        public string Title { get; }
        public string Description { get; }
        public int StoryPoints { get; }
        public User? User { get; set; }
        public Sprint? Sprint { get; set; }
        public List<BacklogItemTask> Tasks { get; set; }

        private readonly BacklogItemState _state;

        public BacklogItem(string title, string description, int storyPoints, User? user = null, Sprint? sprint = null)
        {
            Title = title;
            Description = description;
            StoryPoints = storyPoints;
            User = user;
            Sprint = sprint;
            Tasks = [];
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

        public void AddTask(BacklogItemTask task)
        {
            task.BacklogItem = this;
            Tasks.Add(task);
        }

        public void AddBranch(Branch branch)
        {
            throw new NotImplementedException();
        }

        public void AddForumThread(ForumThread forumThread)
        {
            throw new NotImplementedException();
        }

        public void ChangeState(BacklogItemState state)
        {
            throw new NotImplementedException();
        }
    }
}
