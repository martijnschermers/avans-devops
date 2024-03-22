namespace Domain.Pipeline.Actions
{
    public class Package : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Packaging...");
        }
    }
}