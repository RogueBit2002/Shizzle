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


            IUser user = userService.GetUser("laurens@kruis.name");
            LogPostInfo(postService.GetPost(2));

            IGroup group = groupService.GetGroup(1);

            Console.WriteLine(group.name);


            foreach(IPost post in )
            {
                LogPostInfo(post);
            }
        }


        static void LogPostInfo(IPost post)
        {
            Console.WriteLine(post.title);
            if (post is IGroupPost)
                Console.WriteLine("GroupPost!");
        }
    }
}
