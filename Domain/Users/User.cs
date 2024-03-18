namespace Domain.Users
{
  public abstract class User(string name, string email)
  {

    public void Update(string notification)
    {
      Console.WriteLine($"Hey {name}, you've got a new notification: {notification}");
    }
  }
}
