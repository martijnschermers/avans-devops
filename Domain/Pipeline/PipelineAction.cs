namespace Domain.Pipeline
{
    public abstract class PipelineAction
    {
        public abstract void Execute();

        public abstract void AddAction(PipelineAction action);

        public abstract void RemoveAction(PipelineAction action);
    }
}