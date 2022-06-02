using Shizzle.Data;
using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Factory
{
    public static class CommentServiceFactory
    {
        public static ICommentService CreateService()
        {
            return new CommentService(CreateDataService());
        }

        private static ICommentDataService CreateDataService()
        {
            return new CommentDataService();
        }
    }
}
