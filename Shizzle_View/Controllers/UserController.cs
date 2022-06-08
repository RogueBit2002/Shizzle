using Microsoft.AspNetCore.Mvc;

namespace Shizzle.View.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
