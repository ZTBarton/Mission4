using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission4.Models;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private movieContext _movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, movieContext movieCtx)
        {
            _logger = logger;
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
            return View("submitMovie");
        }

        [HttpPost]
        public IActionResult SubmitMovie(movieTemplate model)
        {
            _movieContext.Add(model);
            _movieContext.SaveChanges();
            return View("confirmation", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
