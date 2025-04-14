using BeerApp.Server.Core;
using Microsoft.EntityFrameworkCore;

namespace BeerApp.Server.Infra.Repos
{
    public class BeerRepository : IBeerRepository
    {
        private readonly BeerDbContext _beerDbContext;

        public BeerRepository(BeerDbContext beerDbContext )
        {
            _beerDbContext = beerDbContext ?? throw new ArgumentNullException(nameof(beerDbContext));
        }

        public async Task<List<BeerEntity>> GetBeersWithMostReviewsAsync()
        {
            //TODO: Need to omptimize this query, a materialized view could be something to look into
            return await _beerDbContext.Beers
                .OrderByDescending(b => b.Reviews.Count)
                .Take(20)
                .ToListAsync();
        }


        public async Task<BeerEntity?> GetBeerByIdAsync(int beerId)
        {
            return await _beerDbContext.Beers.Where(b => b.Id == beerId).SingleOrDefaultAsync();
        }

        public async Task<List<BeerEntity>> GetBeersBySearch(string beerName)
        {
            return await _beerDbContext.Beers
                .Where(b => b.Name.Contains(beerName))
                .Take(20)
                .ToListAsync();
        }

        public async Task<List<ReviewEntity>> GetReviewsByBeerIdAsync(int beerId)
        {
            return await _beerDbContext.Reviews
                .Where(r => r.BeerId == beerId)
                .OrderByDescending(r => r.CreatedAt)
                .Take(20)
                .ToListAsync();
            
        }

        public async Task<int> AddBeerAsync(BeerEntity beer)
        {
            _beerDbContext.Beers.Add(beer);
            await _beerDbContext.SaveChangesAsync();
            return beer.Id;

        }

        public async Task<int> AddReviewAsync(ReviewEntity review)
        {
            _beerDbContext.Reviews.Add(review);
            await _beerDbContext.SaveChangesAsync();
            return review.Id;
        }

        public Task DeleteBeerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReviewAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBeerAsync(BeerEntity beer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReviewAsync(ReviewEntity review)
        {
            throw new NotImplementedException();
        }
    }
}
