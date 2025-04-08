using BeerApp.Server.Controllers.ApiModels.Request;
using BeerApp.Server.Core;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet(Name = "GetBeersMostReviews")]
    public async Task<IActionResult> GetBeers()
    {
        try
        {
            var beers = await _beerService.GetBeersMostReviewedAsync();
            return Ok(beers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting beers");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("search", Name = "GetBeersByQuery")]
    public async Task<IActionResult> GetBeersBySearch([FromQuery] string beerName)
    {
        try
        {
            var beers = await _beerService.GetBeersBySearchAsync(beerName);
            return Ok(beers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting beers");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}", Name = "GetBeerById")]
    public async Task<IActionResult> GetBeerById([FromRoute] string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int beerId))
            {
                return BadRequest("Invalid or missing Beer ID is required");
            }

            var beer = await _beerService.GetBeerByIdAsync(beerId);
            return Ok(beer);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting beer");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}/reviews", Name = "GetBeerReviews")]
    public async Task<IActionResult> GetBeerReviewsById([FromRoute] string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int beerId))
            {
                return BadRequest("Invalid or missing Beer ID is required");
            }

            var beers = await _beerService.GetReviewsForBeerByIdAsync(beerId);
            return Ok(beers);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting beers");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost(Name = "AddBeer")]
    public async Task<IActionResult> AddBeer([FromBody] BeerApiModel beer)
    {
        try
        {
            var beerId = await _beerService.AddBeerAsync(beer);
            return CreatedAtAction(nameof(GetBeerById), new {id = beerId });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating beer");
            return StatusCode(500, "Internal server error");
        }
    }
}
