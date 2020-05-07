using BobFit.Api.SDK.Consumers;
using BobFit.Api.SDK.Models;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace BobFit.Api.SDK.Tests.Integration
{
    public class JwtTokenGenerator
    {
        private IConfiguration _configuration;
        private ApiConsumerConfig _apiConsumerConfig;

        [SetUp]
        public void Setup()
        {
            _configuration = new ConfigurationBuilder()
                .AddUserSecrets<JwtTokenGenerator>()
                .Build();

            _apiConsumerConfig = new ApiConsumerConfig(_configuration);           
        }

        [Test]
        public void GenerateToken()
        {
            var apiClient = new ApiConsumer(_apiConsumerConfig);
            var token = apiClient.GetToken();
        }
    }
}
