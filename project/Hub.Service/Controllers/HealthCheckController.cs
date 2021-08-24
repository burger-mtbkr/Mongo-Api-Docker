using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Hub.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
		[ProducesResponseType(typeof(Boolean), (int)HttpStatusCode.OK)]
		public ActionResult<Boolean> Get()
		{			
			return Ok(true);
		}
    }
}
