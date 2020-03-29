using Microsoft.AspNetCore.Mvc;

namespace NextNms.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class EntryPointController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Hello world!");
        }
    }
}