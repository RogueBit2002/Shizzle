using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal class Post : IPost
    {
        public string title { get; set; }

        public string content { get; set; }

        public uint authorId { get; set; }

        public bool edited { get; set; }

        public DateTime date { get; set; }

        public uint id { get; set; }

        public bool deleted { get; set; }

        public Post(uint id, string title, string content, uint authorId, DateTime date, bool edited, bool deleted)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.authorId = authorId;
            this.date = date;
            this.edited = edited;
            this.deleted = deleted;
        }
    }
}
