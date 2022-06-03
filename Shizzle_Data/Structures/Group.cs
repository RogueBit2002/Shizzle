using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal class Group : IGroup
    {
        public string name { get; set; }

        public string description { get; set; }

        public uint ownerId { get; set; }

        public uint[] adminIds { get; set; }

        public uint[] memberIds { get; set; }

        public uint id { get; set; }

        public bool deleted { get; set; }

        public Group(uint id, string name, string description, uint ownerId, uint[] adminIds, uint[] memberIds, bool deleted)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.ownerId = ownerId;
            this.adminIds = adminIds;
            this.memberIds = memberIds;
            this.deleted = deleted;
        }
    }
}
