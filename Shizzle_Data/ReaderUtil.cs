using MySql.Data.MySqlClient;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal static class ReaderUtil
    {
        #region User
        public static IEnumerable<IUser> GetUsers(this MySqlDataReader reader)
        {
            IUser user;
            while((user = GetUser(reader)) != null)
                yield return user;
        }

        public static IUser GetUser(this MySqlDataReader reader)
        {
            if (!reader.Read())
                return null;
            
            return new User(
                    reader.GetUInt32("id"),
                    reader.GetString("name"),
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetString("biography"));
        }
        #endregion


        #region Post
        public static IEnumerable<IPost> GetPosts(this MySqlDataReader reader)
        {
            IPost post;
            while ((post = GetPost(reader)) != null)
                yield return post;
        }

        public static IPost GetPost(this MySqlDataReader reader)
        {
            if (!reader.Read())
                return null;

            if (reader.IsDBNull(reader.GetOrdinal("group_id")))
                return new Post(
                        reader.GetUInt32("id"),
                        reader.GetString("title"),
                        reader.GetString("content"),
                        reader.GetUInt32("author_id"),
                        reader.GetDateTime("date"),
                        reader.GetBoolean("edited"));
            else
                return new GroupPost(
                        reader.GetUInt32("id"),
                        reader.GetString("title"),
                        reader.GetString("content"),
                        reader.GetUInt32("author_id"),
                        reader.GetDateTime("date"),
                        reader.GetBoolean("edited"),
                        reader.GetUInt32("group_id"));
        }


        #endregion
    }
}
