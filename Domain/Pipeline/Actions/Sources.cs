namespace Domain.Pipeline.Actions
{
  public class Sources : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Fetching sources...");
    }
  }
}
