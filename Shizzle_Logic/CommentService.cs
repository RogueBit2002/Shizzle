using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Logic
{
    public class CommentService : ICommentService
    {
        public uint authorityId { get; set; }
        private ICommentDataService dataService;
        private IPostDataService postDataService;
        private IGroupDataService groupDataService;
        
        public CommentService(ICommentDataService dataService, IPostDataService postDataService, IGroupDataService groupDataService)
        {
            this.dataService = dataService;
            this.postDataService = postDataService;
            this.groupDataService = groupDataService;
        }
        public Structures.IComment CreateComment(string content, uint postId)
        {
            throw new NotImplementedException();
        }

        public void DeleteComment(uint id)
        {
            IComment comment = dataService.GetComment(id);
            if(authorityId == comment.authorId)
            {
                dataService.DeleteComment(id);
                return;
            } else
            {
                IPost post = postDataService.GetPost(comment.postId);
                if(post is IGroupPost)
                {
                    IGroupPost groupPost = post as IGroupPost;
                    IGroup group = groupDataService.GetGroup(groupPost.id);

                    if(group.adminIds.Contains(authorityId))
                    {
                        dataService.DeleteComment(id);
                        return;
                    }
                }
            }

            throw new SecurityException();
        }

        public void EditContent(uint id,string content)
        {
            if()
        }

        public Structures.IComment GetComment(uint id)
        {
            return dataService.GetComment(id);
        }

        public IEnumerable<Structures.IComment> GetCommentsByPost(uint postId)
        {
            return dataService.GetCommentsByPost(postId);
        }

        public IEnumerable<Structures.IComment> GetCommentsByUser(uint userId)
        {
            return dataService.GetCommentsByUser(userId);
        }
    }
}
