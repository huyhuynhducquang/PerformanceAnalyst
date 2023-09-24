using PerformanceAnalyst.Models;

namespace PerformanceAnalyst.Repositories
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Get();
        Movie? GetById(int id);
        void Create(Movie movie);
        void Edit(Movie movie);
        void Delete(int id);
    }
}
