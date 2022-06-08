using Shizzle.IData;
using Shizzle.ILogic;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Logic
{
	public class UserService : IUserService
	{
        public uint authorityId { get; set; }

		private IUserDataService dataService;

        public UserService(IUserDataService userDataService)
        {
            this.dataService = userDataService;
        }

        public Structures.IUser CreateUser(string name, string email, string password)
        {
            return dataService.CreateUser(name, email, Security.HashPassword(password));
        }

        public void DeleteUser(uint id)
        {
            if (id != authorityId)
                throw new SecurityException();

            dataService.DeleteUser(id);
        }

        public Structures.IUser GetUser(uint id)
        {
            return dataService.GetUser(id);
        }

        public Structures.IUser GetUser(string email)
        {
            return dataService.GetUser(email);
        }

        public void SetBiography(uint id, string biography)
        {
            if (id != authorityId)
                throw new SecurityException();

            dataService.SetBiography(id, biography);
        }

        public void SetEmail(uint id, string email)
        {
            if (id != authorityId)
                throw new SecurityException();

            if (dataService.GetUser(email) != null)
                throw new ArgumentException();

            dataService.SetEmail(id, email);
        }

        public void SetName(uint id, string name)
        {
            if (id != authorityId)
                throw new SecurityException();

            dataService.SetName(id, name);
        }

        public void SetPassword(uint id, string password)
        {
            if (id != authorityId)
                throw new SecurityException();

            dataService.SetPassword(id, Security.HashPassword(password));
        }

        public bool TryLogin(uint id, string password)
        {

            IUser user = dataService.GetUser(id);

            string hashedPassword = Security.HashPassword(password);

            return user.password == hashedPassword;
        }
    }
}
