using Shizzle.Structures;
using System;

namespace Shizzle.ILogic
{
	public interface IUserService : ISecureService
	{
		public IUser CreateUser(string name, string email, string password);
		public void DeleteUser(uint id);
		public IUser GetUser(uint id);
		public IUser GetUser(string email);
		public void SetName(uint id, string name);
		public void SetEmail(uint id, string email);
		public void SetPassword(uint id, string password);
		public void SetBiography(uint id, string biography);
		public bool TryLogin(uint id, string password);
	}
}
