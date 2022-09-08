using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP8.Models;

namespace TP8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Series = BD.GetSeries();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public List<Temporada> VerTemporadas(int IdSerie)
        {
            return BD.GetTemporadas(IdSerie);
        }

        public List<Actor> VerActores(int IdSerie)
        {
            return BD.GetActores(IdSerie);
        }
        public Serie VerInfo(int IdSerie)
        {
            return BD.GetInfo(IdSerie);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
