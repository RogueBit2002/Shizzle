using Microsoft.AspNetCore.Mvc;

namespace Shizzle.View.Controllers
{
    public class LogoutController : AuthController
    {
        public IActionResult Index()
        {
            Logout();

            return RedirectToLoginPage(false);
        }
    }
}
