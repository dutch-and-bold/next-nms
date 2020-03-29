using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextNms.Libraries.Contracts;

namespace NextNms.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDiscoverDevices _discoverDevices;

        public DevicesController(IDiscoverDevices discoverDevices)
        {
            _discoverDevices = discoverDevices;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }
    }
}