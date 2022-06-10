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

            PostModel model = post is IGroupPost ? 
                new GroupPostModel(
                    post, 
                    ServiceLocator.Locate<IUserService>().GetUser(post.authorId),
                    comments,
                    ServiceLocator.Locate<IGroupService>().GetGroup(((IGroupPost)post).groupId)
                )
                : new PostModel(post,
                    ServiceLocator.Locate<IUserService>().GetUser(post.authorId),
                    comments);

            return View(model);
        }
    }
}
