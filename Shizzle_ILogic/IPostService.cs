using Shizzle.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.ILogic
{
    public interface IPostService : ISecureService
    {
        public IPost CreatePost(string title, string content);
        public IPost CreatePost(string title, string content, uint groupId);

        public void DeletePost(uint id);
        public IPost GetPost(uint id);
        public IEnumerable<IPost> GetPostsByUser(uint userId);
        public IEnumerable<IPost> GetPostsByGroup(uint groupId);
        public void EditTitle(uint id, string title);
        public void EditContent(uint id, string content);
    }
}
