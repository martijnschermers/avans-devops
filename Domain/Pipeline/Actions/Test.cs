namespace Domain.Pipeline.Actions
{
  public class Test : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Testing...");
    }
  }
}