using BeerApp.Server.Controllers.ApiModels;
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
            List<BeerApiModel> beers = new List<BeerApiModel>() 
            { 
                new BeerApiModel()
                {
                    Id = 1,
                    Description = "1",
                    ImageUrl = "1",
                    Name = "1",
                    Rating = "1"
                }   
            };
            return Ok(beers);
        }
    }
}
