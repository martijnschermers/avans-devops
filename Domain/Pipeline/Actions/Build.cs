namespace Domain.Pipeline.Actions
{
  public class Build : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Building...");
    }
  }
}