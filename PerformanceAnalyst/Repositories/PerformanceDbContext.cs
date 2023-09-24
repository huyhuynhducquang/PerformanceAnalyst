using Microsoft.EntityFrameworkCore;
using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Repositories
{
    public class PerformanceDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public PerformanceDbContext(DbContextOptions<PerformanceDbContext> options) : base(options)
        {
            base.Database.EnsureCreated();
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var movieBuilder = modelBuilder.Entity<Movie>();

            movieBuilder
                .HasKey(x => x.Id);

            movieBuilder
                .Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            movieBuilder
                .Property(x => x.Author)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
