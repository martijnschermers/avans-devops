namespace Domain.Pipeline.Actions
{
    public class Utility : PipelineAction
    {
        protected List<PipelineAction> _children = new List<PipelineAction>();

        public override void Execute()
        {
            Console.WriteLine("Executing Utility...");
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