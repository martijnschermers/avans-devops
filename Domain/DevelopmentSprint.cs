namespace Domain
{
  public class DevelopmentSprint(string name, DateTime startDate, DateTime endDate) : Sprint(name, startDate, endDate)
  {
    public void StartSprintReview()
    {
      // Start the sprint
      Console.WriteLine("Sprint started!");
      // Add your sprint logic here
    }
  }
}