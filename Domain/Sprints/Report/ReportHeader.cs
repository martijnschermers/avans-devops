using System.Text;

namespace Domain.Sprints.Report
{
    public class ReportHeader(string companyName, string projectName, string version, DateTime date) : ReportComponent()
    {
        public override string Print()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Report Header");
            stringBuilder.AppendLine("Company Name: " + companyName);
            stringBuilder.AppendLine("Project Name: " + projectName);
            stringBuilder.AppendLine("Version: " + version);
            stringBuilder.AppendLine("Date: " + date);
            return stringBuilder.ToString();
        }
    }
}