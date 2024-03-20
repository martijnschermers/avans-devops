namespace Domain.Pipeline.Actions
{
  public class Analysis : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Analyzing...");
    }
  }
}