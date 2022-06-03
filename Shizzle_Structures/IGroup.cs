using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Structures
{
    public interface IGroup : IIdentifiable
    {
        public string name { get; }
        public string description { get; }
        public uint ownerId { get; }
        public uint[] adminIds { get; }
        public uint[] memberIds { get; }
    }
}
