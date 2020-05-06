using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BobFit.Api.Controllers
{
    [Route("api/activity")]
    public class ActivityController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get()
        {
            return new List<string>() { "Run", "Cycle" };
        }
    }
}
