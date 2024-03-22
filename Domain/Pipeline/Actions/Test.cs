namespace Domain.Pipeline.Actions
{
    public class Test : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Testing...");
        }
    }
}