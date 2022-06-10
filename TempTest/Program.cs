using Shizzle.Factory;
using Shizzle.ILogic;
using Shizzle.Structures;

using System;

namespace TempTest
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            IUserService userService = UserServiceFactory.CreateService();
            IPostService postService = PostServiceFactory.CreateService();
            IGroupService groupService = GroupServiceFactory.CreateService();
            ICommentService commentService = CommentServiceFactory.CreateService();

        }

    }
}
