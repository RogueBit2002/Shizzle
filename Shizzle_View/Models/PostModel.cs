using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class PostModel : PostPreviewModel
    {
        public readonly IEnumerable<CommentModel> comments;

        public PostModel(IPost post, IUser author, IEnumerable<CommentModel> comments)
            : base(post, author)
        {
            this.comments = comments;
        }
    }
}
