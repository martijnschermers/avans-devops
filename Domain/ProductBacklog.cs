using Domain.BacklogItems;

namespace Domain
{
    public class ProductBacklog()
    {
        public readonly List<BacklogItem> BacklogItems = [];

        public void AddBacklogItem(BacklogItem item)
        {
            BacklogItems.Add(item);
        }
    }
}