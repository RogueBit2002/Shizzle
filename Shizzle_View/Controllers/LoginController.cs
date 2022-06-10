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
        public IActionResult Index(string redirect)
        {
            LoginModel model = new LoginModel(
                HttpContext.Session.Keys.Contains(failedAttemptKey),
                redirect == null ? "/home" : redirect);

            HttpContext.Session.Remove(failedAttemptKey);

            return View(model);
        }

        public IActionResult TryLogin(IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];
            string redirect = collection["redirect"] == "" ? "/home" : collection["redirect"];
            
            IUserService service = ServiceLocator.Locate<IUserService>();

            IUser user = service.GetUser(email);

            HttpContext.Session.Set(failedAttemptKey, new byte[] { });

            if (user == null)
                return RedirectToLoginPage();

            if(service.TryLogin(user.id, password))
            {
                SetCurrentUser(user.id);
                HttpContext.Session.Remove(failedAttemptKey);

                return Redirect(redirect);
            }

            return RedirectToLoginPage();
        }
    }
}
