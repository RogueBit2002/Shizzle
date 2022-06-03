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
        public static IEnumerable<User> GetUsers(this MySqlDataReader reader)
        {
            User user;
            while((user = GetUser(reader)) != null)
                yield return user;
        }

        public static User GetUser(this MySqlDataReader reader)
        {
            if (!reader.Read())
                return null;
            
            return new User(
                    reader.GetUInt32("id"),
                    reader.GetString("name"),
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetString("biography"),
                    reader.GetBoolean("deleted"));
        }
        #endregion


        #region Post
        public static IEnumerable<Post> GetPosts(this MySqlDataReader reader)
        {
            Post post;
            while ((post = GetPost(reader)) != null)
                yield return post;
        }

        public static Post GetPost(this MySqlDataReader reader)
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
                        reader.GetBoolean("edited"),
                        reader.GetBoolean("deleted"));
            else
                return new GroupPost(
                        reader.GetUInt32("id"),
                        reader.GetString("title"),
                        reader.GetString("content"),
                        reader.GetUInt32("author_id"),
                        reader.GetDateTime("date"),
                        reader.GetBoolean("edited"),
                        reader.GetBoolean("deleted"),
                        reader.GetUInt32("group_id"));
        }


        #endregion


        #region Group
        public static IEnumerable<Group> GetGroups(this MySqlDataReader reader)
        {
            Group group;
            while((group = GetGroup(reader)) != null)
            {
                yield return group;
            }
        }

        public static Group GetGroup(this MySqlDataReader reader)
        {
            if (!reader.Read())
                return null;


            return new Group(
                reader.GetUInt32("id"),
                reader.GetString("name"),
                reader.GetString("description"),
                reader.GetUInt32("owner_id"),
                null,
                null,
                reader.GetBoolean("deleted"));

        }
        #endregion
    }
}
