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
    public class PostService : IPostService
    {
        public uint authorityId { get; set; }
        private IPostDataService dataService;
        private IUserDataService userDataService;

        public PostService(IPostDataService dataService)
        {
            this.dataService = dataService;
        }
        public Structures.IPost CreatePost(string title, string content)
        {
            return dataService.CreatePost(title, content, authorityId);
        }

        public Structures.IPost CreatePost(string title, string content, uint groupId)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(uint id)
        {
            //TODO: Check if you're the owner, or an admin of the group post
            dataService.DeletePost(id);
        }

        public void EditContent(uint id, string content)
        {
            IPost post = dataService.GetPost(id);

            if (post.authorId != authorityId)
                throw new SecurityException();

            dataService.EditContent(id, content);
            dataService.MarkAsEdited(id);
        }

        public void EditTitle(uint id, string title)
        {
            IPost post = dataService.GetPost(id);

            if (post.authorId != authorityId)
                throw new SecurityException();

            dataService.EditTitle(id, title);
            dataService.MarkAsEdited(id);
        }

        public Structures.IPost GetPost(uint id)
        {
            return dataService.GetPost(id);
        }

        public IEnumerable<Structures.IPost> GetPostsByGroup(uint groupId)
        {
            return dataService.GetPostsByGroup(groupId);
        }

        public IEnumerable<Structures.IPost> GetPostsByUser(uint userId)
        {
            return dataService.GetPostsByUser(userId);
        }
    }
}
