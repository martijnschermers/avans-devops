namespace Domain.Pipeline.Actions
{
  public class Deploy : IPipelineAction
  {
    public void Execute()
    {
      Console.WriteLine("Deploying...");
    }
  }
}