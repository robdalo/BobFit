using BobFit.Api.DataAccess.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BobFit.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/activity")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityRepo _activityRepo;

        public ActivityController(IActivityRepo activityRepo)
        {
            _activityRepo = activityRepo;
        }

        [HttpPost]
        public void Add(SDK.Models.Activity activity)
        {
            var activityMapped = new Domain.Models.Activity
            {
                Id = activity.Id,
                Title = activity.Title,
                ActivityType = activity.ActivityType,
                EventDate = activity.EventDate,
                Distance = activity.Distance,
                Duration = activity.Duration
            };

            _activityRepo.Add(activityMapped);
        }

        [HttpGet("{id}")]
        public ActionResult<SDK.Models.Activity> Get(int id)
        {
            var activity = _activityRepo.Get(id);
            var activityMapped = new SDK.Models.Activity
            {
                Id = activity.Id,
                Title = activity.Title,
                ActivityType = activity.ActivityType,
                EventDate = activity.EventDate,
                Distance = activity.Distance,
                Duration = activity.Duration                
            };

            return activityMapped;
        }

        [HttpGet]
        public ActionResult<List<SDK.Models.Activity>> Get()
        {
            var activities = _activityRepo.Get();
            var activitiesMapped = activities.Select(a => new SDK.Models.Activity {
                Id = a.Id,
                Title = a.Title,
                ActivityType = a.ActivityType,
                EventDate = a.EventDate,
                Distance = a.Distance,
                Duration = a.Duration
            });

            return activitiesMapped.ToList();
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _activityRepo.Remove(id);
        }
    }
}
