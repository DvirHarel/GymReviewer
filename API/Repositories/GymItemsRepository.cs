using WebApplication2;

namespace GymReviewer.API.Repositories
{
     public interface GymItemsRepository
    {
        GymItem GetItem(Guid id);
        IEnumerable<GymItem> GetItems();
        void CreateItem(GymItem item);
        void UpdateItem(GymItem item);
        void DeleteItem(Guid id);
    }
}
