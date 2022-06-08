using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Shizzle.View.Controllers
{
    public class BaseController : Controller
    {
        protected bool IsLoggedIn()
        {
            if (!HttpContext.Session.Keys.Contains("user-id"))
                return false;

            //uint id = HttpContext.Session.GetUInt32("user-id")
            return true;

            
        }


        protected IActionResult RedirectToLoginPage()
        {
            return View("/");
        }


    }
}
