using Shizzle.Structures;

namespace Shizzle.View.Models
{
    public class CommentModel
    {
        public IComment comment;
        public IUser author;
        public IPost post;
        
        public CommentModel(IComment comment, IUser author, IPost post)
        {
            this.comment = comment;
            this.author = author;
            this.post = post;
        }    
    }
}
