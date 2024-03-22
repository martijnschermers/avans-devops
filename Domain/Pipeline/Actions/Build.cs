namespace Domain.Pipeline.Actions
{
    public class Build : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Building...");
        }
    }
}