using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal class Comment : IComment
    {
        public uint postId { get; set; }

        public string content { get; set; }

        public uint authorId { get; set; }

        public bool edited { get; set; }

        public DateTime date { get; set; }

        public uint id { get; set; }

        public bool deleted { get; set; }

        public Comment(uint id, string content, uint authorId, uint postId, DateTime date, bool edited, bool deleted)
        {
            this.id = id;
            this.content = content;
            this.authorId = authorId;
            this.postId = postId;
            this.date = date;
            this.edited = edited;
            this.deleted = deleted;
        }
    }
}
