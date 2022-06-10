using Shizzle.Structures;

namespace Shizzle.View.Models
{
    public class CommentModel
    {
        public readonly IComment comment;
        public readonly IUser author;
        public readonly IPost post;
        
        public CommentModel(IComment comment, IUser author, IPost post)
        {
            this.comment = comment;
            this.author = author;
            this.post = post;
        }    
    }
}
