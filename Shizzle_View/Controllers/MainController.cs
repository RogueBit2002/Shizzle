using Microsoft.AspNetCore.Mvc;
using Shizzle.View.Models;
using System.Diagnostics;

namespace Shizzle.View.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View("../Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
