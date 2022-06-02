using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Structures
{
    public interface IPost : IContentContainer
    {
        public string title { get; }
    }
}
