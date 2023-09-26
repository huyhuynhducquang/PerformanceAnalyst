using Microsoft.AspNetCore.Mvc;
using PerformanceAnalyst.Models;
using PerformanceAnalyst.Repositories;

namespace PerformanceAnalyst.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            var movies = _movieRepository.Get();
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.Create(movie);
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
        
        public IActionResult Edit(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var existingMovie = _movieRepository.GetById(id);

                if (existingMovie == null)
                    return NotFound();
                    
                existingMovie.Name = movie.Name;
                existingMovie.Author = movie.Author;

                _movieRepository.Edit(movie);

                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
                return NotFound();

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _movieRepository.GetById(id);

            if (movie == null)
                return NotFound();
                
            _movieRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
