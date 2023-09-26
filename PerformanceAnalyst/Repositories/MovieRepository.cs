using Dapper;
using Microsoft.EntityFrameworkCore;
using PerformanceAnalyst.Models;
using System.Data;

namespace PerformanceAnalyst.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly PerformanceDbContext _dbContext;

        public MovieRepository(PerformanceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Movie> Get()
        {
            return _dbContext.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            return _dbContext.Movies.FirstOrDefault(_ => _.Id == id);
        }

        public void Create(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public void Edit(Movie movie)
        {
            _dbContext.Update(movie);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
            }
        }
    }
}
