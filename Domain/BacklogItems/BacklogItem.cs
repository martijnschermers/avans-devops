using Domain.Sprints;
using Domain.Forum;
using Domain.Git;
using Domain.Users;
using Domain.BacklogItems.States;
using Domain.Notifications;

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
        public ForumThread? ForumThread { get; set; }
        public Branch? Branch { get; set; }
        private BacklogItemState _state;
        private INotificationService _notificationService;

        public BacklogItem(string title, string description, int storyPoints, User? user = null, Sprint? sprint = null)
        {
            Title = title;
            Description = description;
            StoryPoints = storyPoints;
            User = user;
            Sprint = sprint;
            Tasks = [];
            _state = new Todo(this);
            _notificationService = new EmailNotificationService();
        }

        public void AddUser(User user)
        {
            if (User != null)
            {
                return;
            }

            _notificationService.Attach(user);
            User = user;
        }

        public void AddTask(BacklogItemTask task)
        {
            task.BacklogItem = this;
            Tasks.Add(task);
        }

        public void AddBranch(Branch branch)
        {
            Branch = branch;
        }

        public void AddForumThread(ForumThread forumThread)
        {
            ForumThread = forumThread;
        }

        public void ChangeState(BacklogItemState state)
        {
            // The state can't be changed to doing if the state is done
            if (state is Doing && _state is Done)
            {
                return;
            }

            // Send a notification to the tester if a backlog item is ready for testing
            if (state is ReadyForTesting)
            {
                foreach (var user in _notificationService.GetSubscribers())
                {
                    if (user.GetType() == typeof(Tester))
                    {
                        _notificationService.Notify(user, "The backlog item " + Title + " is ready for testing");
                    }
                }
            }

            // Send a notification if a backlog item is set back to the todo state
            if (state is Todo)
            {
                foreach (var user in _notificationService.GetSubscribers())
                {
                    if (user.GetType() == typeof(ScrumMaster))
                    {
                        _notificationService.Notify(user, "The backlog item " + Title + " is set back to the todo state");
                    }
                }
            }

            _state = state;
        }
    }
}
