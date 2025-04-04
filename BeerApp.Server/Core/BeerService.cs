namespace BeerApp.Server.Core
{
    public class BeerService
    {
        private readonly IBeerRepository _beerRepository;
        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository ?? throw new ArgumentNullException(nameof(beerRepository));
        }

        public async Task<List<BeerDto>> GetBeersMostReviewedAsync()
        {
            return await _beerRepository.GetBeersWithMostReviewsAsync();
        }

        public async Task<List<BeerDto>> GetBeersBySearch(string beerName)
        {
            return await _beerRepository.GetBeersBySearch(beerName);
        }

        public async Task<BeerDto> GetBeerById(int beerId)
        {
            return await _beerRepository.GetBeerByIdAsync(beerId);
        }

        public async Task<List<ReviewDto>> GerReviewsForBeerById(int beerId)
        {
            return await _beerRepository.GetReviewsByBeerIdAsync(beerId);   
        }
    }
}
