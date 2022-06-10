using Microsoft.AspNetCore.Mvc;
using Shizzle.ILogic;
using Shizzle.Structures;
using Shizzle.View.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shizzle.View.Controllers
{
    public class GroupController : AuthController
    {
        public IActionResult Index(string id)
        {
            if (!IsLoggedIn())
                return RedirectToLoginPage();

            uint groupId;

            try
            {
                groupId = uint.Parse(id);
            } catch
            {
                return View("NotFound");
            }

            IGroup group = ServiceLocator.Locate<IGroupService>().GetGroup(groupId);

            if (group == null)
                return View("NotFound");

            IUser owner = ServiceLocator.Locate<IUserService>().GetUser(group.ownerId);

            IEnumerable<PostPreviewModel> posts = 
                ServiceLocator.Locate<IPostService>().GetPostsByGroup(groupId).Select(
                    post => new PostPreviewModel(post, ServiceLocator.Locate<IUserService>().GetUser(post.authorId))
                );
           
            GroupModel model = new GroupModel(group, owner, posts);
            return View(model);
        }

    }
}
