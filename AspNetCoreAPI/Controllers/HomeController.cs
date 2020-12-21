/**
 * 
 * AspNetCore API Template
 * (C) 2020 Alessio Saltarin
 * MIT LICENSE
 * 
 **/

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreAPI.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
