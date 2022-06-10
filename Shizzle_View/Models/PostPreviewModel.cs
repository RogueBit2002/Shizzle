using Shizzle.Structures;

namespace Shizzle.View.Models
{
    public class PostPreviewModel
    {
        public readonly IPost post;
        public readonly IUser author;

        public PostPreviewModel(IPost post, IUser author)
        {
            this.post = post;
            this.author = author;
        }
    }
}
