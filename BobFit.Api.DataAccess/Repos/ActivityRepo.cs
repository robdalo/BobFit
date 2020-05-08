using BobFit.Api.Domain.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

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
        
        public List<Activity> Get()
        {
            var database = _mongoClient.GetDatabase(DatabaseName);
            var collection = database.GetCollection<Activity>(CollectionName);

            return collection.AsQueryable().ToList();
        }

        public void Remove(Activity activity)
        {
            var database = _mongoClient.GetDatabase(DatabaseName);
            var collection = database.GetCollection<Activity>(CollectionName);

            collection.DeleteOne(a => a.Id == activity.Id);
        }

        public void Remove(int id)
        {
            var database = _mongoClient.GetDatabase(DatabaseName);
            var collection = database.GetCollection<Activity>(CollectionName);

            collection.DeleteOne(a => a.Id == id);
        }
    }
}
