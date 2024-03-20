namespace Domain.Pipeline.Actions
{
  public class Utility : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Performing utility tasks...");
    }
  }
}