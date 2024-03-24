namespace Domain.Git
{
  public class Repository
  {
    public string Name { get; set; }
    public string ProgrammingLanguage { get; set; }

    public List<Branch> Branches { get; set; }

    public Repository(string name, string programmingLanguage)
    {
      Name = name;
      ProgrammingLanguage = programmingLanguage;

      // Initialize the default master branch
      Branches = [
        new Branch("master", this)
      ];
    }

    public void CreateBranch(string branchName)
    {
      // Create a new branch
      Branches.Add(new Branch(branchName, this));
    }

    public void AddBranch(Branch branch)
    {
      // Add a branch to the repository
      Branches.Add(branch);
    }

    public void DeleteBranch(string branchName)
    {
      // Find the branch and remove it
      Branches = Branches.Where(b => b.Name != branchName).ToList();
    }
  }
}