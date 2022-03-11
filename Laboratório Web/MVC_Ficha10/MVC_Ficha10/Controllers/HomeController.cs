using Ficha10;
using Ficha10.Controllers;
using Ficha10.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_Ficha10.Models;
using System.Diagnostics;

namespace MVC_Ficha10.Controllers
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
            Characters c = JsonLoader.LoadCharactersJson();

            //CharactersController ncc = new CharactersController();
            //return View(new Characters(ncc.Get().ToList()));
            return View(c);
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