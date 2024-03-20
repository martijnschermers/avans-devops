namespace Domain.Git
{
  public class Branch(string name, Repository repository)
  {
    public string Name { get; set; } = name;
    public Repository Repository { get; set; } = repository;

    public List<Commit> Commits { get; set; } = [];

    public void AddCommit(Commit commit)
    {
      // Add the commit to the branch
      Commits.Add(commit);
    }
  }
}