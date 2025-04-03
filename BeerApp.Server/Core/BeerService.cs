namespace BeerApp.Server.Core
{
    public class BeerService
    {
        private readonly IBeerRepository _beerRepository;
        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository ?? throw new ArgumentNullException(nameof(beerRepository));
        }



        public async Task<List<BeerDto>> GetBeersAsync()
        {
            return await _beerRepository.GetBeersAsync();
        }
    }
}
