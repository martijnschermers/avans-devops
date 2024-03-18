namespace Domain.Sprints.Report
{
    public class SprintReport(string title, string body)
    {
        private List<ReportComponent> _components = [];

        public void AddComponent(ReportComponent component)
        {
            _components.Add(component);
        }

        public void RemoveComponent(ReportComponent component)
        {
            _components.Remove(component);
        }

        public void Print()
        {
            Console.WriteLine("Sprint Report");
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Body: " + body);
            Console.WriteLine("Components:");
            foreach (var component in _components)
            {
                component.Print();
            }
        }
    }
}