using Microsoft.AspNetCore.Mvc;
using Shizzle.Factory;
using Shizzle.ILogic;
using Shizzle.Structures;
using Shizzle.View.Models;
using System;
using System.Collections.Generic;

namespace Shizzle.View.Controllers
{
    public class UserController : AuthController
    {
        public IActionResult Index(string id)
        {
            if (!IsLoggedIn())
                return RedirectToLoginPage();

            if (id == null)
                return View("NotFound");

            uint userId = 0;

            try
            {
                userId = uint.Parse(id);
            } catch(Exception e)
            {
                return View("NotFound");
            }

            IUser user = ServiceLocator.Locate<IUserService>().GetUser(userId);

            if (user == null)
                return View("NotFound");


            IEnumerable<IPost> posts = ServiceLocator.Locate<IPostService>().GetPostsByUser(userId);

            UserModel model = new UserModel(user,posts);
            return View(model);
        }
    }
}
