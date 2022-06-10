using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shizzle.View.Models;

namespace Shizzle.View.Controllers
{
    public class RegisterController : Controller
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

            
            
            return Redirect("/home");    
        }
    }
}
