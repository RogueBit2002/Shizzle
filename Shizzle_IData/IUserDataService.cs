using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.IData
{
	public interface IUserDataService
	{
		public IUser CreateUser(string name, string email, string password);
		public void DeleteUser(uint id, string password);
		public IUser GetUser(uint id);
		public IUser GetUser(string email);
		public void SetName(uint id, string name);
		public void SetEmail(uint id, string email);
		public void SetPassword(uint id, string password);
		public void SetBiography(uint id, string biography);
	}
}
