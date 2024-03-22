namespace Domain.Users.Strategies
{
    public class ScrumMaster(string name, string email) : IUserStrategy
    {
        public void Update(string notification)
        {
            Console.WriteLine($"Hey {name} ({email}), you've got a new notification: {notification}");
        }
    }
}