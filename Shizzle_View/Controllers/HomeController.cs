using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shizzle.ILogic;
using Shizzle.Structures;
using Shizzle.View.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Shizzle.View.Controllers
{
    public class HomeController : AuthController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (!IsLoggedIn())
                return RedirectToLoginPage();

            IUser user = ServiceLocator.Locate<IUserService>().GetUser(GetCurrentUser());

            IEnumerable<IGroup> groups = ServiceLocator.Locate<IGroupService>().GetGroupsByUserParticipation(user.id);

            List<PostPreviewModel> posts = new List<PostPreviewModel>();

            foreach(IGroup group in groups)
            {
                foreach(IGroupPost post in ServiceLocator.Locate<IPostService>().GetPostsByGroup(group.id))
                {
                    PostPreviewModel preview = new PostPreviewModel(post, ServiceLocator.Locate<IUserService>().GetUser(post.authorId), group);
                    posts.Add(preview);
                }
            }

            posts.Sort((a, b) => a.post.date.CompareTo(b.post.date));

            HomeModel model = new HomeModel(user, posts);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
