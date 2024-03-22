namespace Domain.Pipeline.Actions
{
    public class Utility : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Performing utility tasks...");
        }
    }
}