using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Structures
{
    public interface IEntity
    {
        public uint id { get; }
        public bool deleted { get; }
    }
}
