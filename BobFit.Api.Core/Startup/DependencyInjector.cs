using BobFit.Api.DataAccess.Repos;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace BobFit.Api.Core.Startup
{
    public class DependencyInjector
    {
        private string _mongoConnectionString;

        public DependencyInjector(string mongoConnectionString)
        {
            _mongoConnectionString = mongoConnectionString;
        }

        public void Configure(IServiceCollection services)
        {
            services.AddSingleton<IMongoClient>(new MongoClient(_mongoConnectionString));
            services.AddSingleton<IActivityRepo, ActivityRepo>();
        }
    }
}
