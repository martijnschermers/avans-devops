namespace Domain.Pipeline
{
    public abstract class PipelineAction
    {
        public abstract void Execute();
        public virtual void AddAction()
        {
            throw new NotImplementedException();
        }
        public virtual void RemoveAction()
        {
            throw new NotImplementedException();
        }
    }
}