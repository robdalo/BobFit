using BobFit.Api.Domain.Models;

namespace BobFit.Api.DataAccess.Repos
{
    public interface IActivityRepo
    {
        void Add(Activity activity);
        Activity Get(int id);
        void Remove(Activity activity);
    }
}
