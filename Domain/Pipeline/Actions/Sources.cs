namespace Domain.Pipeline.Actions
{
    public class Sources : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Fetching sources...");
        }
    }
}
