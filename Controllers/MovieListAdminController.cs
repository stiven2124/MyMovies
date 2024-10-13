using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using MyMovies.Data;
using MyMovies.Models;

namespace MyMovies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieListAdminController : Controller
    {
        public readonly ApplicationDbContext _ctx;

        public MovieListAdminController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }


        public IActionResult Index()
        {
            var movie = _ctx.Movies.ToList();
            if (movie == null) { return NotFound(); }
            return View(movie);
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
                _ctx.Movies.Add(movie);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = _ctx.Movies.Find(id);
            if (movie == null) { return NotFound(); }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movie movie,int id)
        {
            if(id != movie.MovieId) { return BadRequest(); }
            if (ModelState.IsValid)
            {
                _ctx.Movies.Update(movie);
                _ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return  View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = _ctx.Movies.Find(id);
            if (movie == null) { return NotFound(); }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = _ctx.Movies.Find(id);
            _ctx.Movies.Remove(movie);
            _ctx.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}
