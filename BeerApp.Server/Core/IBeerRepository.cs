namespace BeerApp.Server.Core
{
    public interface IBeerRepository
    {
        Task<List<BeerEntity>> GetBeersWithMostReviewsAsync();
        Task<List<BeerEntity>> GetBeersBySearch(string beerName);
        Task<BeerEntity?> GetBeerByIdAsync(int id);
        Task<List<ReviewEntity>> GetReviewsByBeerIdAsync(int beerId);
        Task<int> AddBeerAsync(BeerEntity beer);
        Task UpdateBeerAsync(BeerEntity beer);
        Task DeleteBeerAsync(int id);
        Task<int> AddReviewAsync(ReviewEntity review);
        Task UpdateReviewAsync(ReviewEntity review);
        Task DeleteReviewAsync(int id);
    }
}
