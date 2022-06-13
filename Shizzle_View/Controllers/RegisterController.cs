using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shizzle.ILogic;
using Shizzle.Structures;
using Shizzle.View.Models;

namespace Shizzle.View.Controllers
{
    public class RegisterController : AuthController
    {
        private const string emailErrorKey = "email-error";
        public IActionResult Index()
        {
            RegisterModel model = new RegisterModel(HttpContext.Session.GetString(emailErrorKey));
            HttpContext.Session.Remove(emailErrorKey);

            return View(model);
        }

        public IActionResult TryRegister(IFormCollection formCollection)
        {
            string email = formCollection["email"];
            string password = formCollection["password"];
            string name = formCollection["name"];

            if(ServiceLocator.Locate<IUserService>().GetUser(email) != null)
            {
                HttpContext.Session.SetString(emailErrorKey, "Email already taken");
                return Redirect("/register");
            }

            IUser user = ServiceLocator.Locate<IUserService>().CreateUser(name, email, password);
            SetCurrentUser(user.id);

            return Redirect("/home");    
        }
    }
}
