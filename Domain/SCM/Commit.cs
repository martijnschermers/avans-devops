namespace SCM
{
  public class Commit
  {
    private string Message { get; set; }
    private string Author { get; set; }

    public Commit(string message, string author)
    {
      Message = message;
      Author = author;
    }
  }
}