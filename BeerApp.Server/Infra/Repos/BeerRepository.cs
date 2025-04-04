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

        public async Task<List<BeerDto>> GetBeersWithMostReviewsAsync()
        {
            //TODO: Need to omptimize this query, a materialized view could be something to look into
            return await _beerDbContext.Beers
                .OrderByDescending(b => b.Reviews.Count)
                .Take(20)
                .ToListAsync();
        }


        public async Task<BeerDto> GetBeerByIdAsync(int beerId)
        {
            return await _beerDbContext.Beers.Where(b => b.Id == beerId).SingleAsync();
        }

        public async Task<List<BeerDto>> GetBeersBySearch(string beerName)
        {
            return await _beerDbContext.Beers
                .Where(b => b.Name.Contains(beerName))
                .Take(20)
                .ToListAsync();
        }

        public async Task<List<ReviewDto>> GetReviewsByBeerIdAsync(int beerId)
        {
            return await _beerDbContext.Reviews
                .Where(r => r.BeerId == beerId)
                .OrderByDescending(r => r.CreatedAt)
                .Take(20)
                .ToListAsync();
            
        }

        public Task AddBeerAsync(BeerDto beer)
        {
            throw new NotImplementedException();
        }

        public Task AddReviewAsync(ReviewDto review)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBeerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteReviewAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBeerAsync(BeerDto beer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateReviewAsync(ReviewDto review)
        {
            throw new NotImplementedException();
        }
    }
}
