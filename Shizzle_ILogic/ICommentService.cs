using Shizzle.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.ILogic
{
    public interface ICommentService : ISecureService
    {
        public IComment CreateComment(string content, int postId);
        public void DeleteComment(int id);
        public IComment GetComment(int id);
        public IComment[] GetCommentsByPost(int postId);
        public IComment[] GetCommentsByUser(int userId);
        public void EditContent(string content);

    }
}
