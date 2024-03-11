namespace SCM
{
  public class Branch
  {
    private string Name { get; set; }
    private string Repository { get; set; }

    private List<Commit> Commits { get; set; }

    public Branch(string name, string repository)
    {
      Name = name;
      Repository = repository;
      Commits = [];
    }
  }
}