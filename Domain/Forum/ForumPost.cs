using Users;

namespace Forum
{
  public class ForumPost(string title, string body, User user)
  {
    public void EditPost(string newTitle, string newBody)
    {
      // Edit the post
      Console.WriteLine("Post edited!");
      // Add your post logic here
    }

    public void ReportPost()
    {
      // Report the post
      Console.WriteLine("Post reported!");
      // Add your post logic here
    }
  }
}