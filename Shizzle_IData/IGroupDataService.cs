using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.IData
{
    public interface IGroupDataService
    {
		public IGroup CreateGroup(string name, string description, uint ownerId);
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
