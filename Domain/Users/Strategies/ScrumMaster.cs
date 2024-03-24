using Domain.BacklogItems;

namespace Domain.Users.Strategies
{
    public class ScrumMaster(string name, string email) : IUserStrategy
    {
        public void Update(string notification)
        {
            Console.WriteLine($"Hey {name} ({email}), you've got a new notification: {notification}");
        }

        public void AssignBacklogItem(IBacklogItem backlogItem)
        {
            Console.WriteLine("Only developers or testers can be added to " + backlogItem.Title + ", not Scrum Masters!");
        }
    }
}