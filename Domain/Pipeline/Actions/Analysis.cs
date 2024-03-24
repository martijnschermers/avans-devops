namespace Domain.Pipeline.Actions
{
    public class Analysis : PipelineAction
    {
        protected List<PipelineAction> _children = [];

        public override void Execute()
        {
            Console.WriteLine("Executing Analysis...");
            foreach (PipelineAction child in _children)
            {
                child.Execute();
            }
        }

        public override void AddAction(PipelineAction action)
        {
            _children.Add(action);
        }

        public override void RemoveAction(PipelineAction action)
        {
            _children.Remove(action);
        }
    }
}