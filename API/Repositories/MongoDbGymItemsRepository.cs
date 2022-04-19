using GymReviewer.API.Repositories;
using MongoDB.Driver;

namespace WebApplication2.API.Repositories
{
    public class MongoDbGymItemsRepository: GymItemsRepository
    {       
        private const string databaseName = "Gym";

        private const string collectionName = "GymItems";

        private readonly IMongoCollection<GymItem> gymItemsCollection;

        private readonly FilterDefinitionBuilder<GymItem> filterBuilder = Builders<GymItem>.Filter;

        public MongoDbGymItemsRepository(IMongoClient mongoClient)
        {
            //Will be created the first time when needed
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            gymItemsCollection = database.GetCollection<GymItem>(collectionName);
        }

        public void CreateItem(GymItem item)
        {
            gymItemsCollection.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public GymItem GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GymItem> GetItems()
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(GymItem item)
        {
            throw new NotImplementedException();
        }
    }
}
