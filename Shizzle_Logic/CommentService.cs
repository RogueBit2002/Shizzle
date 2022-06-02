using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Logic
{
    public class CommentService : ICommentService
    {
        public int authorityId { get; set; }
        private ICommentDataService dataService;
        
        public CommentService(ICommentDataService dataService)
        {
            this.dataService = dataService;
        }
        public IComment CreateComment(string content, int postId)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(int id)
        {
            throw new NotImplementedException();
        }

        public void EditContent(string content)
        {
            throw new NotImplementedException();
        }

        public IComment GetComment(int id)
        {
            throw new NotImplementedException();
        }

        public IComment[] GetCommentsByPost(int postId)
        {
            throw new NotImplementedException();
        }

        public IComment[] GetCommentsByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
