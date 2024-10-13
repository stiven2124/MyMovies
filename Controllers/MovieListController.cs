using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Data;

namespace MyMovies.Controllers
{
    [Authorize(Roles = "User")]
    public class MovieListController : Controller
    {
        private readonly ApplicationDbContext _ctx;
        public MovieListController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public ActionResult Index()
        {
            var movies = _ctx.Movies.ToList();
            if(movies == null) { return NotFound(); }
            return View(movies);
        }
    }
}
