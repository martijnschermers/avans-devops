namespace Report
{
  public abstract class ReportComponent(string companyName, string companyLogo, string projectName, string version, DateTime date)
  {
    public void Print()
    {
      Console.WriteLine("Company Name: " + companyName);
      Console.WriteLine("Company Logo: " + companyLogo);
      Console.WriteLine("Project Name: " + projectName);
      Console.WriteLine("Version: " + version);
      Console.WriteLine("Date: " + date);
    }
  }
}