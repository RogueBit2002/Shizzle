using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Shizzle.Logic
{
    public class PostService : IPostService
    {
        public uint authorityId { get; set; }
        private IPostDataService dataService;
        private IUserDataService userDataService;
        private IGroupDataService groupDataService;
        public PostService(IPostDataService dataService, IUserDataService userDataService, IGroupDataService groupDataService)
        {
            this.dataService = dataService;
            this.userDataService = userDataService;
            this.groupDataService = groupDataService;
        }
        public Structures.IPost CreatePost(string title, string content)
        {
            title = title.Trim();
            content = content.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                throw new ArgumentException();

            return dataService.CreatePost(title, content, authorityId);
        }

        public Structures.IPost CreatePost(string title, string content, uint groupId)
        {
            title = title.Trim();
            content = content.Trim();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                throw new ArgumentException();

            bool isMember = false;
            foreach(IGroup group in groupDataService.GetGroupsByUserParticipation(groupId))
            {
                if(group.id == groupId)
                {
                    isMember = true;
                    break;
                }
            }

            if (!isMember)
                throw new SecurityException();

            return dataService.CreatePost(title, content, authorityId, groupId);
        }

        public void DeletePost(uint id)
        {
            IPost post = dataService.GetPost(id);

            if(post is IGroupPost)
            {
                IGroup group = groupDataService.GetGroup(post.id);

                if (group.adminIds.Contains(authorityId) || group.ownerId == authorityId)
                {
                    dataService.DeletePost(id);
                    return;
                }
            } else
            {
                if (post.authorId == authorityId)
                {
                    dataService.DeletePost(id);
                    return;
                }
            }

            throw new SecurityException();

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
