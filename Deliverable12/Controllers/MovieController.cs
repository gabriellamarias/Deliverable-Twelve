using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deliverable12.Models;

namespace Deliverable12.Controllers
{
    public class TempMovieData
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie() {ID= 1, Title = "Coraline", Genre = "Horror", Year = 2009, Actor = "Dakota Fanning", Director = "Henry Selick" }
        };

    }
    public class MovieController : Controller
    {
        private List<Movie> _allMovies;

        public MovieController()
        {
            _allMovies = TempMovieData.Movies;
        }
        // GET: MovieController
        public ActionResult Index()
        {
            return View(_allMovies);
        }

        public ActionResult UpdatedIndex(Movie newMovie)
        {
            ViewData["movie"] = $"{newMovie.Title} has been added to the registry";
            return View("Index", _allMovies);
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID", "Title", "Genre", "Year", "Actor", "Director")]Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TempMovieData.Movies.Add(newMovie);
                    return RedirectToAction(nameof(UpdatedIndex), newMovie);
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MovieController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
