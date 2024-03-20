using Domain.BacklogItems;

namespace Domain
{
    public class ProductBacklog()
    {
        private readonly List<BacklogItem> BacklogItems = [];

        public void AddBacklogItem(BacklogItem item)
        {
            BacklogItems.Add(item);
        }
    }
}