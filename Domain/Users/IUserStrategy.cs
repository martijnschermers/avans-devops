using Domain.BacklogItems;

namespace Domain.Users
{
    public interface IUserStrategy
    {
        void Update(string notification);
        void AssignBacklogItem(IBacklogItem backlogItem);
    }
}
