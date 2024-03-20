namespace Domain.Pipeline.Actions
{
  public class Package : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Packaging...");
    }
  }
}