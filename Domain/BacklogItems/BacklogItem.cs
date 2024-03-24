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
        public IUserStrategy? User { get; set; }
        public Sprint? Sprint { get; set; }
        public List<BacklogItemTask> Tasks { get; set; }
        public Branch? Branch { get; set; }
        public BacklogItemState State { get; private set; }
        public bool HasBeenDone { get; set; }
        public bool ReadyForTesting { get; set; }
        public INotificationService NotificationService { get; }
        private ForumThread? _forumThread;

        public BacklogItem(string title, string description, int storyPoints, INotificationService notificationService, IUserStrategy? user = null, Sprint? sprint = null)
        {
            Title = title;
            Description = description;
            StoryPoints = storyPoints;
            User = user;
            Sprint = sprint;
            Tasks = [];
            State = new Todo(this);
            HasBeenDone = false;
            ReadyForTesting = false;
            NotificationService = notificationService;
        }

        public void AddUser(IUserStrategy user)
        {
            if (User != null)
            {
                return;
            }

            NotificationService.Attach(user);
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
            _forumThread = forumThread;
        }

        public void AddForumReaction(ForumPost forumPost)
        {
            if (_forumThread == null)
            {
                throw new InvalidOperationException("Cannot add forum reactions to a backlog item without a forum thread.");
            }

            State.AddForumReaction(_forumThread, forumPost);
        }

        public bool CheckTasksDone()
        {
            // BacklogItem can only be marked as done if all tasks are done
            if (State is Done && Tasks.Exists(task => task.State is not Done))
            {
                return false;
            }
            return true;
        }

        public void ChangeState(BacklogItemState state)
        {
            State = state;
        }

        public void NextState()
        {
            State.SetNextState();
        }

        public void PreviousState()
        {
            State.SetPreviousState();
        }
    }
}
