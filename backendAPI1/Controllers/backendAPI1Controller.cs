using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backendAPI1.Controllers
{
    [ApiController]
    [Route("backendAPI1")]
    public class backendAPI1Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(2000); // Delay for 2 seconds
            return Ok("Hello World from backendAPI1");
        }
    }
}
