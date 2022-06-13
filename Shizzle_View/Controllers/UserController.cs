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
            if (id == null)
                return View("NotFound");

            uint userId;

            try
            {
                userId = uint.Parse(id);
            } catch
            {
                return View("NotFound");
            }

            IUser user = ServiceLocator.Locate<IUserService>().GetUser(userId);

            if (user == null)
                return View("NotFound");


            UserModel model = new UserModel(user, ServiceLocator.Locate<IPostService>().GetPostsByUser(userId));
            return View(model);
        }
    }
}
