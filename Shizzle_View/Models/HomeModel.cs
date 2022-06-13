using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class HomeModel
    {
        public readonly IUser user;
        public readonly IEnumerable<PostPreviewModel> posts;

        public HomeModel(IUser user, IEnumerable<PostPreviewModel> posts)
        {
            this.user = user;
            this.posts = posts;
        }
    }
}
