using Shizzle.Structures;

namespace Shizzle.View.Models
{
    public class PostPreviewModel
    {
        public readonly IPost post;
        public readonly IUser author;
        public readonly IGroup group;

        public PostPreviewModel(IPost post, IUser author, IGroup group)
        {
            this.post = post;
            this.author = author;
            this.group = group;
        }
    }
}
