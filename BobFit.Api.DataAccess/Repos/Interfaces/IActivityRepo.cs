using BobFit.Api.Domain.Models;
using System.Collections.Generic;

namespace BobFit.Api.DataAccess.Repos
{
    public interface IActivityRepo
    {
        void Add(Activity activity);
        Activity Get(int id);
        List<Activity> Get();
        void Remove(Activity activity);
        void Remove(int id);        
    }
}
