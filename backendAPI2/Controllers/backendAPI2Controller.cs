using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backendAPI2.Controllers
{
    [ApiController]
    [Route("backendAPI2")]
    public class backendAPI2Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(4000); // Delay for 4 seconds
            return Ok("Hello World from backendAPI2");
        }
    }
}
