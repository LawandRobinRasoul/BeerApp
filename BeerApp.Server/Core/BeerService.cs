using BeerApp.Server.Controllers.ApiModels.Request;

namespace BeerApp.Server.Core
{
    public class BeerService
    {
        private readonly IBeerRepository _beerRepository;
        public BeerService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository ?? throw new ArgumentNullException(nameof(beerRepository));
        }

        public async Task<List<BeerEntity>> GetBeersMostReviewedAsync()
        {
            return await _beerRepository.GetBeersWithMostReviewsAsync();
        }

        public async Task<List<BeerEntity>> GetBeersBySearchAsync(string beerName)
        {
            return await _beerRepository.GetBeersBySearch(beerName);
        }

        public async Task<BeerEntity?> GetBeerByIdAsync(int beerId)
        {
            return await _beerRepository.GetBeerByIdAsync(beerId);
        }

        public async Task<List<ReviewEntity>> GetReviewsForBeerByIdAsync(int beerId)
        {
            return await _beerRepository.GetReviewsByBeerIdAsync(beerId);   
        }

        public async Task<int> AddReviewAsync(ReviewApiModel reviewApiModel)
        {
            var reviewEntity = new ReviewEntity
            {
                BeerId = reviewApiModel.BeerId,
                Reviewer = reviewApiModel.username ?? "Anonym",
                BitternesScore = reviewApiModel.BitternessScore,
                FruitinessScore = reviewApiModel.FruitinessScore,
                SweetnessScore  = reviewApiModel.SweetnessScore,
                Rating = reviewApiModel.Rating,
                Comment = reviewApiModel.Comment
            };
            return await _beerRepository.AddReviewAsync(reviewEntity);
        }

        public async Task<int> AddBeerAsync (BeerApiModel beerApiModel)
        {
            var beerEntity = new BeerEntity
            {
                Name = beerApiModel.Name,
                Description = beerApiModel.Description,
                Type = beerApiModel.Type,
                imageUrl = beerApiModel.ImageUrl,
            };
             
           return await _beerRepository.AddBeerAsync(beerEntity);
        }
    }
}
