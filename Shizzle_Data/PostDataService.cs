using Shizzle.IData;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    public class PostDataService : IPostDataService
    {
        public IPost CreatePost(string title, string content)
        {
            throw new NotImplementedException();
        }

        public IPost CreatePost(string title, string content, int groupId)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public void EditContent(int id, string content)
        {
            throw new NotImplementedException();
        }

        public void EditTitle(int id, string title)
        {
            throw new NotImplementedException();
        }

        public IPost GetPost(int id)
        {
            throw new NotImplementedException();
        }

        public IPost[] GetPostsByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public IPost[] GetPostsByUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
