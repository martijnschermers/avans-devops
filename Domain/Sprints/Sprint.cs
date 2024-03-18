using Domain.BacklogItems;
using Domain.Sprints.Report;
using Domain.Sprints.States;
using Domain.Users;

namespace Domain.Sprints
{
    public abstract class Sprint
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BacklogItem> BacklogItems { get; set; }
        public List<User> TeamMembers { get; set; }
        private SprintState _state;


        public Sprint(string name, DateTime startDate, DateTime endDate)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            BacklogItems = [];
            TeamMembers = [];
            _state = new NotStartedSprintState(this);
        }

        public void ChangeState(SprintState state)
        {
            // Change the state to finished if the end date is passed 
            if (state is InProgressSprintState && DateTime.Now > EndDate)
            {
                state = new FinishedSprintState(this);
            }

            _state = state;
        }

        public void Start()
        {
            // Start the sprint
            Console.WriteLine("Sprint started!");
            // Add your sprint logic here
            ChangeState(new InProgressSprintState(this));
        }

        public void Edit(string name, DateTime startDate, DateTime endDate)
        {
            // Check if the sprint is in a state that allows editing
            _state.Edit(name, startDate, endDate);
        }

        public void End()
        {
            // End the sprint
            Console.WriteLine("Sprint ended!");
            // Add your sprint logic here
            ChangeState(new FinishedSprintState(this));
        }

        public void AddBacklogItem(BacklogItem item)
        {
            // Check if the backlogitem is already added to a different sprint 
            if (item.Sprint != null)
            {
                return;
            }

            item.Sprint = this;
            BacklogItems.Add(item);
        }

        public void RemoveBacklogItem(BacklogItem item)
        {
            BacklogItems.Remove(item);
        }

        public void AddTeamMember(User user)
        {
            TeamMembers.Add(user);
        }

        public void RemoveTeamMember(User user)
        {
            TeamMembers.Remove(user);
        }

        public void GenerateReport()
        {
            var report = new SprintReport(Name, "Sprint report body");
            report.AddComponent(new ReportHeader("Company Name", "Company Logo", "Project Name", "Version", DateTime.Now));
            report.AddComponent(new ReportFooter("Company Name", "Company Logo", "Project Name", "Version", DateTime.Now));
            report.Print();
        }
    }
}