using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class MovieController : Controller
    {
        private MovieContext? Context { get; set; }

        public MovieController(MovieContext? ctx)
        {
            Context = ctx;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = Context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieModel movie)
        {
            Context.Movies.Remove(movie);
            Context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add New Movie";
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
            return View("Edit", new MovieModel());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit Movie";
            ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
            //searching for the movie by id/primary key
            var movie = Context.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieModel movie)
        {
            if(ModelState.IsValid)
            {
                if(movie.MovieId == 0)
                {
                    Context.Movies.Add(movie);
                }
                else
                {
                    Context.Movies.Update(movie);
                }
                Context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (movie.MovieId == 0) ? "Add New Movie" : "Edit Movie";
                ViewBag.Genres = Context.Genres.OrderBy(g => g.Name).ToList();
                return View(movie);
            }
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
