using BobFit.Api.SDK.Consumers;
using BobFit.Api.SDK.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.Linq;

namespace BobFit.Api.SDK.Tests.Integration.Consumers
{
    [TestFixture, Ignore("")]
    public class ApiConsumerTests
    {
        private IConfiguration _configuration;
        private ApiConsumerConfig _apiConsumerConfig;
        private ApiConsumer _apiConsumer;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddUserSecrets<ApiConsumerTests>()
                .Build();

            _apiConsumerConfig = new ApiConsumerConfig(_configuration);
            _apiConsumer = new ApiConsumer(_apiConsumerConfig);
        }

        [Test, Ignore("")]
        public void GetActivities_ReturnsOneOrMore()
        {
            var activities = _apiConsumer.GetActivities();
            Assert.IsTrue(activities != null && activities.Any());
        }
    }
}
