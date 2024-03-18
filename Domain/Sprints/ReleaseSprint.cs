namespace Domain.Sprints
{
    public class ReleaseSprint(string name, DateTime startDate, DateTime endDate) : Sprint(name, startDate, endDate)
    {
        public void StartRelease()
        {
            // Release the sprint
            Console.WriteLine("Sprint released!");
            // Add your sprint logic here
        }

        public void CancelRelease()
        {
            // Cancel the release
            Console.WriteLine("Sprint release cancelled!");
            // Add your sprint logic here
        }
    }
}