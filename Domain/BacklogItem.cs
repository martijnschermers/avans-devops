using BacklogItemStates;
using Users;

namespace Domain
{
    public class BacklogItem
    {
        public string Title { get; }
        public string Description { get; }
        public int StoryPoints { get; }
        public User? User { get; set; }
        public Sprint? Sprint { get; set; }

        private readonly BacklogItemState _state;

        public BacklogItem(string title, string description, int storyPoints, User? user = null, Sprint? sprint = null)
        {
            Title = title;
            Description = description;
            StoryPoints = storyPoints;
            User = user;
            Sprint = sprint;
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
    }
}
