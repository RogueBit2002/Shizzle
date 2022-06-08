using Microsoft.AspNetCore.Mvc;

namespace Shizzle.View.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View("../Home/Index");
        }
    }
}
