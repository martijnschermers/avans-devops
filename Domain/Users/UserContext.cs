namespace Domain.Users
{
    public class UserContext
    {
        private IUserStrategy _strategy;

        public UserContext()
        { }

        public UserContext(IUserStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(IUserStrategy strategy)
        {
            this._strategy = strategy;
        }
    }
}
