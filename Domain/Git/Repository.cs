namespace Domain.Git
{
  public class Repository
  {
    private string Name { get; set; }
    private string ProgrammingLanguage { get; set; }

    private List<Branch> Branches { get; set; }

    public Repository(string name, string programmingLanguage)
    {
      Name = name;
      ProgrammingLanguage = programmingLanguage;

      // Initialize the default master branch
      Branches = [
        new Branch("master", Name)
      ];
    }
  }
}