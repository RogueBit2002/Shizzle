using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shizzle.View.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Shizzle.View.Controllers
{
    public class HomeController : AuthController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!IsLoggedIn())
                return RedirectToLoginPage();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
