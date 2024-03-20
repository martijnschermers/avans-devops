using Domain.Users;

namespace Domain.Forum
{
  public class ForumPost(string title, string body, User user)
  {
    public void EditPost(string newTitle, string newBody)
    {
      title = newTitle;
      body = newBody;
      Console.WriteLine("Post edited!");
    }
  }
}