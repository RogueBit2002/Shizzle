using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Structures
{
    public interface IContentContainer : IIdentifiable
    {
        public string content { get; }
        public uint authorId { get; }
        
        public bool edited { get; }
        public DateTime date { get; }
    }
}
