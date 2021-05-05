/*
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreAPI.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }
        
        public IActionResult Index()
        {
            this._logger.LogInformation("GET /");
            ViewData["Title"] = "Asp.Net Core API Template";
            ViewData["Version"] = "0.2.0";
            return View();
        }
    }
}
