using BobFit.Api.DataAccess.Repos;
using BobFit.Api.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NUnit.Framework;
using System;

namespace BobFit.Api.DataAccess.Tests.Integration.Repos
{
    [TestFixture]
    public class ActivityRepoTests
    {
        private IConfiguration _configuration;
        private IMongoClient _mongoClient;
        private IActivityRepo _activityRepo;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets<ActivityRepoTests>()
                .Build();

            var connectionString = _configuration["MongoConnectionString"];

            _mongoClient = new MongoClient(connectionString);
            _activityRepo = new ActivityRepo(_mongoClient);
        }

        [TestCase(13371338, "Test")]        
        public void AddGetRemove_Success(int activityId, string activityTitle)
        {
            var activity = new Activity {
                Id = activityId,
                Title = activityTitle,
                ActivityType = "Mountain Biking",
                EventDate = DateTime.Now,
                Distance = 32.50m,
                Duration = 104.00m
            };

            _activityRepo.Add(activity);

            activity = _activityRepo.Get(activityId);
            var added = (activity?.Title == activityTitle);

            _activityRepo.Remove(activity);

            activity = _activityRepo.Get(activityId);
            var removed = (activity == null);

            Assert.IsTrue(added && removed);
       }
    }
}
