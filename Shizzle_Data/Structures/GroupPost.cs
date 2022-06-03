using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal class GroupPost : Post, IGroupPost
    {
        public uint groupId { get; set; }

        public GroupPost(uint id, string title, string content, uint authorId, DateTime date, bool edited, uint groupId)
            : base(id, title, content, authorId, date, edited)
        {
            this.id = id;
            this.title = title;
            this.content = content;
            this.authorId = authorId;
            this.date = date;
            this.edited = edited;
            this.groupId = groupId;
        }
    }
}
