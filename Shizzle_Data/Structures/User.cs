using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal class User : IUser
    {
        public string password { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string biography { get; set; }

        public uint id { get; set; }

        public bool deleted { get; set; }

        public User(uint id, string name, string email, string password, string biography, bool deleted)
        {
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.biography = biography;
            this.deleted = deleted;
        }
    }
}
