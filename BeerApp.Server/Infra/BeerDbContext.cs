using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;

public class BeerDbContext : DbContext
{
    public BeerDbContext(DbContextOptions<BeerDbContext> options)
        : base(options) { }

    public DbSet<BeerEntity> Beers { get; set; }
    public DbSet<ReviewEntity> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReviewEntity>()
            .HasOne(r => r.Beer)
            .WithMany(b => b.Reviews)
            .HasForeignKey(r => r.BeerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}