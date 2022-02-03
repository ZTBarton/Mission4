using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private movieContext _movieContext { get; set; }

        public HomeController(movieContext movieCtx)
        {
            _movieContext = movieCtx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View("podcasts");
        }

        [HttpGet]
        public IActionResult SubmitMovie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View("submitMovie");
        }

        [HttpPost]
        public IActionResult SubmitMovie(movieTemplate model)
        {
            if (ModelState.IsValid)
            {
            _movieContext.Add(model);
            _movieContext.SaveChanges();
            return View("confirmation", model);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View(model);
            }
            
        }
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _movieContext.Movies
                .Include(x => x.Category)
                .ToList();

            return View("movieList", movies);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();

            var movie = _movieContext.Movies.Single(x => x.MovieID == id);

            return View("editMovie", movie);
        }
        [HttpPost]
        public IActionResult Edit(movieTemplate movie)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Update(movie);
                _movieContext.SaveChanges();
                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();

                return View("editMovie", movie);
            }  
        }
        public IActionResult Delete(int id)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieID == id);

            return View("deleteMovie", movie);
        }
        [HttpPost]
        public IActionResult Delete(movieTemplate movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
