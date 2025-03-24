using Microsoft.AspNetCore.Mvc;

namespace BeerApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly ILogger<BeerController> _logger;

        public BeerController(ILogger<BeerController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GeetBeer")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
