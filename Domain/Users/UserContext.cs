namespace Domain.Users
{
    public class UserContext
    {
        private IUserStrategy _strategy;

        public UserContext()
        { }

        // Usually, the Context accepts a strategy through the constructor, but
        // also provides a setter to change it at runtime.
        public UserContext(IUserStrategy strategy)
        {
            this._strategy = strategy;
        }

        // Usually, the Context allows replacing a Strategy object at runtime.
        public void SetStrategy(IUserStrategy strategy)
        {
            this._strategy = strategy;
        }
    }
}
