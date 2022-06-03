using Shizzle.IData;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    public class GroupDataService : IGroupDataService
    {
        public void AddAdmin(uint id, uint adminId)
        {
            throw new NotImplementedException();
        }

        public IGroup CreateGroup(string name, string dscription)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(uint id)
        {
            throw new NotImplementedException();
        }

        public IGroup GetGroup(uint id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IGroup> GetGroupsByUserParticipation(uint userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdmin(uint id, uint adminId)
        {
            throw new NotImplementedException();
        }

        public void SetDescription(uint id, string description)
        {
            throw new NotImplementedException();
        }

        public void SetName(uint id, string name)
        {
            throw new NotImplementedException();
        }

        public void SetOwner(uint id, uint ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
