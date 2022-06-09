using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shizzle.ILogic;
using Shizzle.Structures;
using Shizzle.View.Models;
using System.Linq;

namespace Shizzle.View.Controllers
{
    public class LoginController : AuthController
    {
        private const string failedAttemptKey = "failed-login-attempt";
        public IActionResult Index()
        {
            LoginModel model = new LoginModel();
            model.failedAttempt = HttpContext.Session.Keys.Contains(failedAttemptKey);

            HttpContext.Session.Remove(failedAttemptKey);
            
            return View(model);
        }

        public IActionResult TryLogin(IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];

            IUserService service = ServiceLocator.Locate<IUserService>();

            IUser user = service.GetUser(email);

            HttpContext.Session.Set(failedAttemptKey, new byte[] { });

            if (user == null)
                return RedirectToLoginPage();

            if(service.TryLogin(user.id, password))
            {
                SetCurrentUser(user.id);
                HttpContext.Session.Remove(failedAttemptKey);

                string redirect = GetRedirectAfterLogin() != null ? GetRedirectAfterLogin() : "/Home";
                ClearRedirectAfterLogin();
                return Redirect(redirect);
            }

            return RedirectToLoginPage();
        }
    }
}
