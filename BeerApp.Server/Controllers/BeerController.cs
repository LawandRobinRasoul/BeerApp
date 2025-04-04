using BeerApp.Server.Controllers.ApiModels;
using BeerApp.Server.Core;
using Microsoft.AspNetCore.Mvc;

namespace BeerApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BeerController : ControllerBase
    {
        private readonly ILogger<BeerController> _logger;
        private readonly BeerService _beerService;

        public BeerController(ILogger<BeerController> logger, BeerService beerService)
        {
            _logger = logger;
            _beerService = beerService;
        }

        [HttpGet(Name = "GeetBeersMostReviews")]
        public IActionResult Get()
        {
            try
            {
                var beers = _beerService.GetBeersMostReviewedAsync().Result;
                return Ok(beers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting beers");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
