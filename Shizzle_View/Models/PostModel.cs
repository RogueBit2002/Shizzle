using Shizzle.Structures;
using System.Collections.Generic;

namespace Shizzle.View.Models
{
    public class PostModel
    {
        public IPost post;
        public IUser author;
        public IGroup group;
        public IEnumerable<CommentModel> comments;

        public PostModel(IPost post, IUser author, IGroup group, IEnumerable<CommentModel> comments)
        {
            this.post = post;
            this.author = author;
            this.group = group;
            this.comments = comments;
        }
    }
}
