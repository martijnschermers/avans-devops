namespace Domain.Git
{
  public class Commit(string message)
  {
    public void EditCommit(string newMessage)
    {
      message = newMessage;
      Console.WriteLine("Commit edited!");
    }
  }
}