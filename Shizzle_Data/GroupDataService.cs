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
        public void AddAdmin(int id, int adminId)
        {
            throw new NotImplementedException();
        }

        public IGroup CreateGroup(string name, string dscription)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IGroup GetGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IGroup[] GetGroupsByUserParticipation(int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdmin(int id, int adminId)
        {
            throw new NotImplementedException();
        }

        public void SetDescription(int id, string description)
        {
            throw new NotImplementedException();
        }

        public void SetName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void SetOwner(int id, int ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
