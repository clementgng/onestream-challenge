using FrontEndAPI.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace frontendWebAPI.Controllers
{
    [ApiController]
    [Route("frontendWebAPI")]
    public class frontendWebAPIController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly BackendApiConfiguration _backendApiConfig;

        public frontendWebAPIController(HttpClient httpClient, IOptions<BackendApiConfiguration> backendApiConfig)
        {
            _httpClient = httpClient;
            _backendApiConfig = backendApiConfig.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Call backendAPI1 and backendAPI2 asynchronously
            var backendapi1Task = _httpClient.GetStringAsync(_backendApiConfig.BackendAPI1Url);
            var backendapi2Task = _httpClient.GetStringAsync(_backendApiConfig.BackendAPI2Url);

            // Wait for both backend tasks to complete
            await Task.WhenAll(backendapi1Task, backendapi2Task);

            // Return the responses from both APIs
            return Ok(new
            {
                BackendAPI1Response = await backendapi1Task,
                BackendAPI2Response = await backendapi2Task
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] HelloWorldRequest request)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return Ok($"Hello, {request.Name}!");
        }
    }

    public class HelloWorldRequest
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot be more than 50 characters.")]
        public required string Name { get; set; }
    }
}
