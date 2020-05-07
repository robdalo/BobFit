using BobFit.Api.SDK.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;

namespace BobFit.Api.SDK.Consumers
{
    public class ApiConsumer
    {
        private ApiConsumerConfig _config;

        private RestConsumer _restConsumer;
        
        private const string GetActivitiesEndpoint = "activity";

        public ApiConsumer(ApiConsumerConfig config)
        {
            _config = config;

            _restConsumer = new RestConsumer(_config.BaseUrl);
        }

        public List<string> GetActivities()
        {
            var authToken = GetToken();

            var activities = _restConsumer.Get<List<string>>(GetActivitiesEndpoint, authToken);

            return activities;
        }

        public string GetToken()
        {
            var cca = ConfidentialClientApplicationBuilder.Create(_config.ClientId)
                .WithClientSecret(_config.ClientSecret)
                .WithAuthority(new Uri(_config.Authority))
                .Build();

            var resourceIds = new string[] { _config.ResourceId };

            var result = cca.AcquireTokenForClient(resourceIds).ExecuteAsync().Result;

            return result.AccessToken;
        }
    }
}
