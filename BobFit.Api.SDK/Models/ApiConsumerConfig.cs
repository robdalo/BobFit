using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace BobFit.Api.SDK.Models
{
    public class ApiConsumerConfig
    {
        public string Instance;
        public string TenantId;
        public string ClientId;
        public string ResourceId;
        public string ClientSecret;
        public string BaseUrl;
        public string Authority => string.Format(CultureInfo.InvariantCulture, $"{Instance}/{TenantId}");

        public ApiConsumerConfig()
        {
        }

        public ApiConsumerConfig(IConfiguration configuration)
        {
            Instance = configuration["Instance"];
            TenantId = configuration["TenantId"];
            ClientId = configuration["ClientId"];
            ResourceId = configuration["ResourceId"];
            ClientSecret = configuration["ClientSecret"];
            BaseUrl = configuration["BaseUrl"];
        }
    }
}
