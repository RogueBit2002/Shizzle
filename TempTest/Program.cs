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

            LogPostInfo(postService.GetPost(2));
        }


        static void LogPostInfo(IPost post)
        {
            Console.WriteLine(post.title);
            if (post is IGroupPost)
                Console.WriteLine("GroupPost!");

        }
    }
}
