using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Shizzle.View.Controllers
{
    public class AuthController : Controller
    {
        private const string userIdKey = "user-id";
        protected bool IsLoggedIn()
        {
            if (!HttpContext.Session.Keys.Contains(userIdKey))
                return false;

            return true;

            
        }

        protected IActionResult RedirectToLoginPage()
        {
            string path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}{HttpContext.Request.QueryString}";
            SetRedirectAfterLogin(path);
            return Redirect("/Login");
        }


        protected uint GetCurrentUser()
        {
            return HttpContext.Session.GetUInt32(userIdKey);
        }

        protected void SetCurrentUser(uint id)
        {
            HttpContext.Session.SetUInt32(userIdKey, id);
        }

        protected void Logout()
        {
            HttpContext.Session.Remove(userIdKey);
        }

        protected void ClearRedirectAfterLogin()
        {
            HttpContext.Session.Remove("login-redirect");
        }

        protected void SetRedirectAfterLogin(string path)
        {
            HttpContext.Session.SetString("login-redirect", path);
        }

        protected string GetRedirectAfterLogin()
        {
            return HttpContext.Session.GetString("login-redirect");
        }
    }
}
