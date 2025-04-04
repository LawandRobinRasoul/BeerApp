namespace BeerApp.Server.Core
{
    public interface IBeerRepository
    {
        Task<List<BeerDto>> GetBeersWithMostReviewsAsync();
        Task<List<BeerDto>> GetBeersBySearch(string beerName);
        Task<BeerDto> GetBeerByIdAsync(int id);
        Task<List<ReviewDto>> GetReviewsByBeerIdAsync(int beerId);
        Task AddBeerAsync(BeerDto beer);
        Task UpdateBeerAsync(BeerDto beer);
        Task DeleteBeerAsync(int id);
        Task AddReviewAsync(ReviewDto review);
        Task UpdateReviewAsync(ReviewDto review);
        Task DeleteReviewAsync(int id);
    }
}
