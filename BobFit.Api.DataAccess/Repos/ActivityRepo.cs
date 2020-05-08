using BobFit.Api.Domain.Models;
using MongoDB.Driver;

namespace BobFit.Api.DataAccess.Repos
{
    public class ActivityRepo : IActivityRepo
    {
        private readonly IMongoClient _mongoClient;
        public const string CollectionName = "Activity";
        public const string DatabaseName = "BobFit";

        public ActivityRepo(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
        }

        public void Add(Activity activity)
        {
            var database = _mongoClient.GetDatabase(DatabaseName);
            var collection = database.GetCollection<Activity>(CollectionName);

            collection.InsertOne(activity);
        }

        public Activity Get(int id)
        {
            var database = _mongoClient.GetDatabase(DatabaseName);
            var collection = database.GetCollection<Activity>(CollectionName);

            var activity = collection.Find(a => a.Id == id).SingleOrDefault();

            return activity;
        }

        public void Remove(Activity activity)
        {
            var database = _mongoClient.GetDatabase(DatabaseName);
            var collection = database.GetCollection<Activity>(CollectionName);

            collection.DeleteOne(a => a.Id == activity.Id);
        }
    }
}
