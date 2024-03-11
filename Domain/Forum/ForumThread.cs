namespace Forum
{
  public class ForumThread(string title)
  {
    private readonly List<ForumPost> _posts = [];

    public void AddPost(ForumPost post)
    {
      _posts.Add(post);
    }

    public void RemovePost(ForumPost post)
    {
      _posts.Remove(post);
    }

    public void LockThread()
    {
      // Lock the thread
      Console.WriteLine("Thread locked!");
      // Add your thread logic here
    }

    public void UnlockThread()
    {
      // Unlock the thread
      Console.WriteLine("Thread unlocked!");
      // Add your thread logic here
    }

    public void PinThread()
    {
      // Pin the thread
      Console.WriteLine("Thread pinned!");
      // Add your thread logic here
    }

    public void UnpinThread()
    {
      // Unpin the thread
      Console.WriteLine("Thread unpinned!");
      // Add your thread logic here
    }
  }
}