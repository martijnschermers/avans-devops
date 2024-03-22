namespace Domain.Pipeline.Actions
{
    public class Analysis : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}