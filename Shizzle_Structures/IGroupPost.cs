﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Structures
{
    public interface IGroupPost : IPost
    {
        public uint groupId { get; }
    }
}
