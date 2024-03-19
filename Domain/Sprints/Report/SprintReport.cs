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

        public void RemoveComponent(ReportComponent component)
        {
            _components.Remove(component);
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
    }
}