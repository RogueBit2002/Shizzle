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
		public void DeleteUser(int id, string password);
		public IUser GetUser(int id);
		public IUser GetUser(string email);
		public void SetName(int id, string name);
		public void SetEmail(int id, string email);
		public void SetPassword(int id, string password);
		public void SetBiography(int id, string biography);
		public bool TryLogin(int id, string password);
	}
}
