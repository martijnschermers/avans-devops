using Domain.Pipeline.Actions;

namespace Domain.Pipeline
{
  public class DevelopmentPipeline(string name, int duration)
  {
    public List<IPipelineAction> Actions { get; set; } = [];

    public bool Start()
    {
      Console.WriteLine($"Development pipeline {name} started!");
      Console.WriteLine($"Estimated duration: {duration} minutes");

      foreach (var action in Actions)
      {
        action.Execute();
      }

      return true;
    }

    public void AddPipelineAction(IPipelineAction action)
    {
      Actions.Add(action);
    }
  }
}