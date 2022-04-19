using GymReviewer.API.Repositories;

namespace WebApplication2
{
    public class InMemGymItemsRepository: GymItemsRepository
    {
        private readonly List<GymItem> items = new()
        {
            new GymItem { Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Leg Press", Category = "Legs" },
            new GymItem { Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Bench Press", Category = "Chest" },
            new GymItem { Id = Guid.NewGuid(), CreatedDate = DateTimeOffset.UtcNow, Name = "Shoulders Press", Category = "Shoulders" }
        };

        public IEnumerable<GymItem> GetItems()
        {
            return this.items;
        }

        public GymItem GetItem(Guid id)
        {
            GymItem gymItem = items.Where(gymItem => gymItem.Id == id).SingleOrDefault();
            return gymItem;
        }

        public void CreateItem(GymItem item)
        {
            items.Add(item);

        }

        public void UpdateItem(GymItem item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}
