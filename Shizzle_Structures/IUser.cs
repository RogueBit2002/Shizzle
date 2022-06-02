using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Structures
{
    public interface IUser : IIdentifiable
    {
        public string name { get; }
        public string email { get; }
        public string biography { get; }
    }
}
