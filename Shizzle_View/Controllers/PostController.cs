using Microsoft.AspNetCore.Http;
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
            if (id == null)
                return View("NotFound");

            uint postId;

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


            

            List<CommentModel> comments = new List<CommentModel>();

            foreach(IComment comment in ServiceLocator.Locate<ICommentService>().GetCommentsByPost(postId))
            {
                comments.Add(
                    new CommentModel(
                        comment,
                        ServiceLocator.Locate<IUserService>().GetUser(comment.authorId),
                        post
                    )
                );
            }

            if(post is IGroupPost)
            {
                
            }

            PostModel model = new PostModel(
                post, 
                ServiceLocator.Locate<IUserService>().GetUser(post.authorId),
                post is IGroupPost ? ServiceLocator.Locate<IGroupService>().GetGroup(((IGroupPost)post).groupId) : null,
                comments);

            return View(model);
        }


        public IActionResult Create()
        {
            if (!IsLoggedIn())
                return RedirectToLoginPage();

            return View();
        }

        public IActionResult CreatePost(IFormCollection collection)
        {
            return Redirect("Create");
        }
    }
}
