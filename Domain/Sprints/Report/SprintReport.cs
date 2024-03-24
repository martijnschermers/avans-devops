using System.Text;

namespace Domain.Sprints.Report
{
    public class SprintReport(string title)
    {
        private readonly List<ReportComponent> _components = [];

        public void AddComponent(ReportComponent component)
        {
            _components.Add(component);
        }

        public string Print()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Sprint Report");
            stringBuilder.AppendLine("Title: " + title);
            stringBuilder.AppendLine("Components:");
            foreach (var component in _components)
            {
                stringBuilder.AppendLine(component.Print());
            }
            return stringBuilder.ToString();
        }

        public static void Export(ExportOptions exportOption)
        {
            switch (exportOption)
            {
                case ExportOptions.Pdf:
                    Console.WriteLine("Exporting to PDF");
                    break;
                case ExportOptions.Png:
                    Console.WriteLine("Exporting to PNG");
                    break;
                case ExportOptions.Word:
                    Console.WriteLine("Exporting to Word");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(exportOption));
            }
        }
    }
}