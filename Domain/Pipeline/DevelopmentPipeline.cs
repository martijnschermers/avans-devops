using Domain.Pipeline.Actions;

namespace Domain.Pipeline
{
  public class DevelopmentPipeline(string name, int duration)
  {
    public List<IPipelineAction> Actions { get; set; } = [];

    public void Start()
    {
      Console.WriteLine($"Development pipeline {name} started!");
      Console.WriteLine($"Estimated duration: {duration} minutes");
      foreach (var action in Actions)
      {
        action.Execute();
      }
    }

    public void AddPipelineAction(IPipelineAction action)
    {
      // Add the action to the pipeline
      Actions.Add(action);
    }
  }
}