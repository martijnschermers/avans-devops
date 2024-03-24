namespace Domain.Forum
{
  public class ForumPost(string title, string body)
  {
    public string Title { get; set; } = title;
    public string Body { get; set; } = body;

    public void EditPost(string newTitle, string newBody)
    {
      Title = newTitle;
      Body = newBody;
      Console.WriteLine("Post edited!");
    }
  }
}