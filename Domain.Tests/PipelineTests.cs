using Domain.Pipeline;
using Domain.Pipeline.Actions;

namespace Domain.Tests
{
  public class PipelineTests
  {
    [Fact]
    public void ExecutePipelineWithMultipleActions()
    {
      // Arrange
      var pipeline = new DevelopmentPipeline("Development pipeline", 60);
      var action1 = new Build();
      var action2 = new Test();
      var action3 = new Deploy();
      pipeline.AddPipelineAction(action1);
      pipeline.AddPipelineAction(action2);
      pipeline.AddPipelineAction(action3);

      using StringWriter sw = new();
      Console.SetOut(sw);

      // Act
      pipeline.Start();

      // Assert
      Assert.Contains("Build", sw.ToString());
      Assert.Contains("Test", sw.ToString());
      Assert.Contains("Deploy", sw.ToString());

      // Reset the console output
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }

    [Fact]
    public void ExecutePipelineWithActionsThatHaveChildren()
    {
      // Arrange
      var pipeline = new DevelopmentPipeline("Development pipeline", 60);
      var action1 = new Analysis();
      var action2 = new Package();
      var action3 = new Sources();
      var action4 = new Build();
      var action5 = new Test();
      var action6 = new Deploy();
      action1.AddAction(action4);
      action2.AddAction(action5);
      action3.AddAction(action6);
      pipeline.AddPipelineAction(action1);
      pipeline.AddPipelineAction(action2);
      pipeline.AddPipelineAction(action3);

      using StringWriter sw = new();
      Console.SetOut(sw);

      // Act
      pipeline.Start();

      // Assert
      Assert.Contains("Analysis", sw.ToString());
      Assert.Contains("Package", sw.ToString());
      Assert.Contains("Sources", sw.ToString());
      Assert.Contains("Build", sw.ToString());
      Assert.Contains("Test", sw.ToString());
      Assert.Contains("Deploy", sw.ToString());

      // Reset the console output
      Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
    }
  }
}