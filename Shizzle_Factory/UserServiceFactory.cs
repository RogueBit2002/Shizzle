using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Logic;
using Shizzle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Factory
{
    public static class UserServiceFactory
    {
        public static IUserService CreateService()
        {
            return new UserService(CreateDataService());
        }

        public static IUserDataService CreateDataService()
        {
            return new UserDataService();
        }
    }
}
