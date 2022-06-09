using Microsoft.AspNetCore.Mvc;
using Shizzle.ILogic;
using Shizzle.Structures;
using Shizzle.View.Models;
using System.Collections.Generic;

namespace Shizzle.View.Controllers
{
    public class PostController : AuthController
    {
        public IActionResult Index(string id)
        {
            if (!IsLoggedIn())
                return RedirectToLoginPage();

            if (id == null)
                return View("NotFound");

            uint postId = 0;

            try
            {
                postId = uint.Parse(id);
            } catch
            {
                return View("NotFound");
            }

            IPost post = ServiceLocator.Locate<IPostService>().GetPost(postId);

            if (post == null)
                return View("NotFound");

            IUser user = ServiceLocator.Locate<IUserService>().GetUser(post.authorId);
            IEnumerable<IComment> rawComments = ServiceLocator.Locate<ICommentService>().GetCommentsByPost(postId);
            IGroup group = post is IGroupPost ? 
                ServiceLocator.Locate<IGroupService>().GetGroup(
                    ((IGroupPost)post).groupId) 
                : null;

            List<CommentModel> comments = new List<CommentModel>();

            foreach(IComment comment in rawComments)
            {
                comments.Add(
                    new CommentModel(
                        comment,
                        ServiceLocator.Locate<IUserService>().GetUser(comment.authorId),
                        post
                    )
                );
            }

            PostModel model = new PostModel(post, user, group, comments);
            return View(model);
        }
    }
}
