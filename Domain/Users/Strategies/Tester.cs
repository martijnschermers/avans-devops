using Domain.BacklogItems;

namespace Domain.Users.Strategies
{
    public class Tester(string name, string email) : IUserStrategy
    {
        public void Update(string notification)
        {
            Console.WriteLine($"Hey {name} ({email}), you've got a new notification: {notification}");
        }

        public void AssignBacklogItem(IBacklogItem backlogItem)
        {
            backlogItem.AddUser(this);
            Console.WriteLine("Tester added to " + backlogItem.Title);
        }
    }
}