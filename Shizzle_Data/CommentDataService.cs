using Shizzle.IData;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    public class CommentDataService : ICommentDataService
    {
        public IComment CreateComment(string content, uint postId)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(uint id)
        {
            throw new NotImplementedException();
        }

        public void EditContent(string content)
        {
            throw new NotImplementedException();
        }

        public IComment GetComment(uint id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IComment> GetCommentsByPost(uint postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IComment> GetCommentsByUser(uint userId)
        {
            throw new NotImplementedException();
        }
    }
}
