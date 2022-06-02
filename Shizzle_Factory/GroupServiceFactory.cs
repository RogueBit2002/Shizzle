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
    public static class GroupServiceFactory
    {
        public static IGroupService CreateService()
        {
            return new GroupService(CreateDataService());
        }

        public static IGroupDataService CreateDataService()
        {
            return new GroupDataService();
        }
    }
}
