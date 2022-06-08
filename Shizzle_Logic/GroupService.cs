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
    public class GroupService : IGroupService
    {
        public uint authorityId { get; set; }
        private IGroupDataService dataService;

        public GroupService(IGroupDataService dataService)
        {
            this.dataService = dataService;
        }


        public void AddAdmin(uint id, uint adminId)
        {
            IGroup group = dataService.GetGroup(id);
            
            if (group.ownerId != authorityId)
                throw new SecurityException();

            if (group.adminIds.Contains(adminId))
                return;

            dataService.AddAdmin(id, adminId);


        }

        public Structures.IGroup CreateGroup(string name, string description)
        {
            if (GetGroup(name) != null)
                throw new ArgumentException();

            return dataService.CreateGroup(name, description, authorityId);
        }

        public void DeleteGroup(uint id)
        {
            IGroup group = dataService.GetGroup(id);

            if (group.ownerId != authorityId)
                throw new SecurityException();

            dataService.DeleteGroup(id);
        }

        public Structures.IGroup GetGroup(uint id)
        {
            return dataService.GetGroup(id);
        }

        public IEnumerable<Structures.IGroup> GetGroupsByUserParticipation(uint userId)
        {
            return dataService.GetGroupsByUserParticipation(userId);
        }

        public void RemoveAdmin(uint id, uint adminId)
        {
            IGroup group = dataService.GetGroup(id);

            if (group.ownerId != authorityId)
                throw new SecurityException();

            if (!group.adminIds.Contains(adminId))
                return;

            dataService.RemoveAdmin(id, adminId);
        }

        public void SetDescription(uint id, string description)
        {
            IGroup group = dataService.GetGroup(id);

            if (group.ownerId != authorityId)
                throw new SecurityException();

            dataService.SetDescription(id, description);
        }

        /*public void SetName(uint id, string name)
        {
            IGroup group = dataService.GetGroup(id);

            if (group.ownerId != authorityId)
                throw new SecurityException();

            dataService.SetName(id, name);
        }*/

        public void SetOwner(uint id, uint ownerId)
        {
            IGroup group = dataService.GetGroup(id);

            if (group.ownerId != authorityId)
                throw new SecurityException();

            if (!group.adminIds.Contains(ownerId))
                throw new ArgumentException();

            dataService.SetOwner(id, ownerId);
        }

        public Structures.IGroup GetGroup(string name)
        {
            return dataService.GetGroup(name);
        }
    }
}
