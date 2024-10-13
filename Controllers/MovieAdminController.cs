using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyMovies.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
