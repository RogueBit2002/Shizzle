using Shizzle.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.ILogic
{
	public interface IGroupService : ISecureService
	{
		public IGroup CreateGroup(string name, string description);
		public void DeleteGroup(uint id);
		public IGroup GetGroup(uint id);
		public IGroup GetGroup(string name);
		public IEnumerable<IGroup> GetGroupsByUserParticipation(uint userId);
		public void AddAdmin(uint id, uint adminId);
		public void RemoveAdmin(uint id, uint adminId);
		public void SetOwner(uint id, uint ownerId);
		//public void SetName(uint id, string name);
		public void SetDescription(uint id, string description);
	}
}
