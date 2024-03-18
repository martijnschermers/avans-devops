namespace Domain.Sprints.Report
{
    public class ReportFooter(string companyName, string companyLogo, string projectName, string version, DateTime date) : ReportComponent(companyName, companyLogo, projectName, version, date)
    {
        public new void Print()
        {
            Console.WriteLine("Report Footer");
            Console.WriteLine("Company Name: " + companyName);
            Console.WriteLine("Company Logo: " + companyLogo);
            Console.WriteLine("Project Name: " + projectName);
            Console.WriteLine("Version: " + version);
            Console.WriteLine("Date: " + date);
        }
    }
}