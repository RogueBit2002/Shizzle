using System;

namespace Shizzle.Structures.LowLevel
{
    public interface IUser : Structures.IUser
    {
        public string password { get; }
    }
}
