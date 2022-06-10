using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class GroupModel
    {
        public readonly IGroup group;
        public readonly IUser owner;
        public readonly IEnumerable<PostPreviewModel> posts;
        public GroupModel(IGroup group, IUser owner, IEnumerable<PostPreviewModel> posts)
        {
            this.group = group;
            this.owner = owner;
            this.posts = posts;
        }
    }
}
