using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class UserModel
    {
        public readonly IUser user;
        public readonly IEnumerable<IPost> posts;

        public UserModel(IUser user, IEnumerable<IPost> posts)
        {
            this.user = user;
            this.posts = posts;
        }
    }
}
