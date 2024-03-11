using Report;
using Users;
using SprintStates;

namespace Domain
{
  public abstract class Sprint(string _name, DateTime _startDate, DateTime _endDate)
  {
    private SprintState _state = new NotStartedSprintState();
    private readonly List<BacklogItem> _backlogItems = [];
    private readonly List<User> _teamMembers = [];

    public void Start()
    {
      // Start the sprint
      Console.WriteLine("Sprint started!");
      // Add your sprint logic here
    }

    public void Edit(string name, DateTime startDate, DateTime endDate)
    {
      // Check if the sprint is in a state that allows editing
      _state.Edit(name, startDate, endDate);
    }

    public static void End()
    {
      // End the sprint
      Console.WriteLine("Sprint ended!");
      // Add your sprint logic here
    }

    public void AddBacklogItem(BacklogItem item)
    {
      _backlogItems.Add(item);
    }

    public void RemoveBacklogItem(BacklogItem item)
    {
      _backlogItems.Remove(item);
    }

    public void GenerateReport()
    {
      // TODO: Add team to report including story points finished per team member

      var report = new SprintReport(_name, _backlogItems.Count, "Sprint report body");
      report.AddComponent(new ReportHeader("Company Name", "Company Logo", "Project Name", "Version", DateTime.Now));
      report.AddComponent(new ReportFooter("Company Name", "Company Logo", "Project Name", "Version", DateTime.Now));
      report.Print();
    }
  }
}