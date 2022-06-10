using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class GroupPostModel : PostModel
    {
        public readonly IGroup group;
        public GroupPostModel(IPost post, IUser author, IEnumerable<CommentModel> comments, IGroup group)
            : base(post, author, comments)
        {
            this.group = group;
        }
    }
}
