namespace Domain.Pipeline.Actions
{
    public class Deploy : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Deploying...");
        }
    }
}