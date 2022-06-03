﻿using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.IData
{
    public interface ICommentDataService
    {
        public IComment CreateComment(string content, uint postId);
        public void DeleteComment(uint id);
        public IComment GetComment(uint id);
        public IEnumerable<IComment> GetCommentsByPost(uint postId);
        public IEnumerable<IComment> GetCommentsByUser(uint userId);
        public void EditContent(string content);
    }
}
