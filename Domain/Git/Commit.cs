namespace Domain.Git
{
  public class Commit(string message)
  {
    public string Message { get; set; } = message;

    public void EditCommit(string newMessage)
    {
      Message = newMessage;
      Console.WriteLine("Commit edited!");
    }
  }
}