using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Logic
{
    public class CommentService : ICommentService
    {
        public uint authorityId { get; set; }
        private ICommentDataService dataService;
        
        public CommentService(ICommentDataService dataService)
        {
            this.dataService = dataService;
        }
        public Structures.IComment CreateComment(string content, uint postId)
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

        public Structures.IComment GetComment(uint id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Structures.IComment> GetCommentsByPost(uint postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Structures.IComment> GetCommentsByUser(uint userId)
        {
            throw new NotImplementedException();
        }
    }
}
