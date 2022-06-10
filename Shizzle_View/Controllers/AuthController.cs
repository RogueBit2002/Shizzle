using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Web;

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

        protected IActionResult RedirectToLoginPage(bool redirect = true)
        {
            string path = redirect ?
                $"/login?redirect={HttpUtility.UrlEncode($"{HttpContext.Request.Path}{HttpContext.Request.QueryString}")}" : "/login";
            return Redirect(path);
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
    }
}
