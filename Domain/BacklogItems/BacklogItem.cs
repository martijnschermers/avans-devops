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
        public Branch? Branch { get; set; }
        public BacklogItemState State { get; private set; }
        private readonly INotificationService _notificationService;
        private ForumThread? _forumThread;

        public BacklogItem(string title, string description, int storyPoints, INotificationService notificationService, User? user = null, Sprint? sprint = null)
        {
            Title = title;
            Description = description;
            StoryPoints = storyPoints;
            User = user;
            Sprint = sprint;
            Tasks = [];
            State = new Todo(this);
            _notificationService = notificationService;
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

        public void ChangeState(BacklogItemState state)
        {
            // The state can't be changed to doing if the state is done
            //if (state is Doing && State is Done)
            //{
            //    return;
            //}

            //// Send a notification to the tester if a backlog item is ready for testing
            //if (state is ReadyForTesting)
            //{
            //    foreach (var user in _notificationService.GetSubscribers())
            //    {
            //        if (user.GetType() == typeof(Tester))
            //        {
            //            _notificationService.Notify(user, "The backlog item " + Title + " is ready for testing");
            //        }
            //    }
            //}

            //// Send a notification if a backlog item is set back to the to do state
            //if (state is Todo)
            //{
            //    foreach (var user in _notificationService.GetSubscribers())
            //    {
            //        if (user.GetType() == typeof(ScrumMaster))
            //        {
            //            _notificationService.Notify(user, "The backlog item " + Title + " is set back to the todo state");
            //        }
            //    }
            //}

            //// BacklogItem can only be marked as done if all tasks are done
            //if (state is Done && Tasks.Exists(task => task.State is not Done))
            //{
            //    return;
            //}

            State = state;
        }

        public void NextState()
        {
            State.SetNextState();
        }
    }
}
