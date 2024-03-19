using System.Text;

namespace Domain.Sprints.Report
{
  public class ReportBody(string body) : ReportComponent()
  {
    public override string Print()
    {
      var stringBuilder = new StringBuilder();
      stringBuilder.AppendLine("Report Body");
      stringBuilder.AppendLine("Body: " + body);
      return stringBuilder.ToString();
    }
  }
}