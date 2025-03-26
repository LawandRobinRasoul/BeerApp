using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

public class BeerDbContext : DbContext
{
    public BeerDbContext(DbContextOptions<BeerDbContext> options)
        : base(options) { }

    public DbSet<BeerDto> Beers { get; set; }
    public DbSet<ReviewDto> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReviewDto>()
            .HasOne(r => r.Beer)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BeerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}