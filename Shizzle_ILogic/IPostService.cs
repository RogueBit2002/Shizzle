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
        public IPost CreatePost(string title, string content, int groupId);

        public void DeletePost(int id);
        public IPost GetPost(int id);
        public IPost[] GetPostsByUser(int userId);
        public IPost[] GetPostsByGroup(int groupId);
        public void EditTitle(int id, string title);
        public void EditContent(int id, string content);
    }
}
