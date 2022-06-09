using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class UserModel
    {
        public IUser user;
        public IEnumerable<IPost> posts;

        public UserModel(IUser user, IEnumerable<IPost> posts)
        {
            this.user = user;
            this.posts = posts;
        }
    }
}
