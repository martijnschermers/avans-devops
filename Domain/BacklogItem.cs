using Users;

namespace Domain
{
    public class BacklogItem(string title, string description, int storyPoints, string definitionOfDone, string acceptanceCriteria, User user, Sprint? _sprint = null)
    {
        public Sprint? Sprint => _sprint;

        public void SetSprint(Sprint sprint)
        {
            _sprint = sprint;
        }
    }
}
