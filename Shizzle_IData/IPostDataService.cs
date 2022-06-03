using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.IData
{
    public interface IPostDataService
    {
        public IPost CreatePost(string title, string content, uint authorId);
        public IPost CreatePost(string title, string content, uint authorId, uint groupId);

        public void DeletePost(uint id);
        public IPost GetPost(uint id);
        public IEnumerable<IPost> GetPostsByUser(uint userId);
        public IEnumerable<IPost> GetPostsByGroup(uint groupId);
        public void MarkAsEdited(uint id, bool edited = true);
        public void EditTitle(uint id, string title);
        public void EditContent(uint id, string content);
    }
}
