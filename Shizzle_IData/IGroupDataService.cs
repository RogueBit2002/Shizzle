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
		public IGroup CreateGroup(string name, string dscription);
		public void DeleteGroup(int id);
		public IGroup GetGroup(int id);
		public IGroup[] GetGroupsByUserParticipation(int userId);
		public void AddAdmin(int id, int adminId);
		public void RemoveAdmin(int id, int adminId);
		public void SetOwner(int id, int ownerId);
		public void SetName(int id, string name);
		public void SetDescription(int id, string description);
	}
}
