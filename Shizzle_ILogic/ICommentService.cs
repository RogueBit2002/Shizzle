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
        public IComment CreateComment(string content, uint postId);
        public void DeleteComment(uint id);
        public IComment GetComment(uint id);
        public IEnumerable<IComment> GetCommentsByPost(uint postId);
        public IEnumerable<IComment> GetCommentsByUser(uint userId);
        public void EditContent(uint id, string content);

    }
}
