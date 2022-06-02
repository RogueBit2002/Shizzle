using Shizzle.IData;
using Shizzle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shizzle.ILogic;
using Shizzle.Logic;

namespace Shizzle.Factory
{
    public static class PostServiceFactory
    {
        public static IPostService CreateService()
        {
            return new PostService(CreateDataService());
        }

        public static IPostDataService CreateDataService()
        {
            return new PostDataService();
        }
    }
}
