using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Data;

namespace MyMovies.Controllers
{
    [Authorize(Roles = "User")]
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public MovieController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index(int id)
        {
            var movie = _ctx.Movies.FirstOrDefault(m =>m.MovieId == id);
            if (movie == null) {return NotFound();}
            return View(movie);
        }
        public IActionResult Rate(int id)
        {
            var movie = _ctx.Movies.Find(id);
            if (movie == null) { return NotFound(); }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Rate(int id, float rtg)
        {
            var movie = _ctx.Movies.Find(id);
            if (movie == null) { return NotFound(); }
           
            if (movie.AverageRating == null)
            {
                movie.RatingCount++;
                movie.RatingSum = rtg;
                movie.AverageRating = rtg;
            }
            else
            {
                movie.RatingCount++;
                movie.RatingSum = movie.RatingSum + rtg;
                _ctx.SaveChanges();
                movie.AverageRating = movie.RatingSum / movie.RatingCount;
            }
            _ctx.SaveChanges();

            return RedirectToAction("Index",new {id =movie.MovieId});
        }
    }
}
