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
	public class UserService : IUserService
	{
        public int authorityId { get; set; }
		private IUserDataService userDataService;

        public UserService(IUserDataService userDataService)
        {
            this.userDataService = userDataService;
        }

        public IUser CreateUser(string name, string email, string password)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id, string password)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SetBiography(int id, string biography)
        {
            throw new NotImplementedException();
        }

        public void SetEmail(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void SetName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public bool TryLogin(int id, string password)
        {
            throw new NotImplementedException();
        }
    }
}
