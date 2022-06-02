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
    public class PostService : IPostService
    {
        public int authorityId { get; set; }
        private IPostDataService dataService;

        public PostService(IPostDataService dataService)
        {
            this.dataService = dataService;
        }
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
