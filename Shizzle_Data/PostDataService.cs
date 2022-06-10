using MySql.Data.MySqlClient;
using Shizzle.IData;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    public class PostDataService : IPostDataService
    {
        public IPost CreatePost(string title, string content, uint authorId)
        {
            try
            {
                string query = @"INSERT INTO `post`(`title`, `content`, `author_id`) VALUES
    (@title, @content, @authorId);";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("title", title);
                command.Parameters.AddWithValue("content", content);
                command.Parameters.AddWithValue("authorId", authorId);

                command.ExecuteNonQuery();

                return GetPost((uint)command.LastInsertedId);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IGroupPost CreatePost(string title, string content, uint authorId, uint groupId)
        {
            try
            {
                string query = @"INSERT INTO `post`(`title`, `content`, `author_id`,`group_id`) VALUES
    (@title, @content, @authorId, @groupId);";

                

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("title", title);
                command.Parameters.AddWithValue("content", content);
                command.Parameters.AddWithValue("authorId", authorId);
                command.Parameters.AddWithValue("groupId", groupId);
                
                command.ExecuteNonQuery();

                return GetPost((uint)command.LastInsertedId) as IGroupPost;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void DeletePost(uint id)
        {
            try
            {
                string query = $"UPDATE `post` SET `deleted`=1 WHERE `id`=@id;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("id", id);

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void EditContent(uint id, string content)
        {
            try
            {
                string query = $"UPDATE `post` SET `content`=@content WHERE `id`=@id;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("content", content);

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void EditTitle(uint id, string title)
        {
            try
            {
                string query = $"UPDATE `post` SET `title`=@title WHERE `id`=@id;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("title", title);
                command.Parameters.AddWithValue("id", id);

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IPost GetPost(uint id)
        {
            try
            {
                string query = "SELECT * FROM `post` WHERE `id`=@id LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());
                command.Parameters.AddWithValue("id", id);

                MySqlDataReader reader = command.ExecuteReader();

                IPost post = reader.GetPost();

                reader.Close();

                return post;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IEnumerable<IGroupPost> GetPostsByGroup(uint groupId)
        {
            
            try
            {
                string query = "SELECT * FROM `post` WHERE `group_id`=@groupId;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("groupId", groupId);

                MySqlDataReader reader = command.ExecuteReader();

                IEnumerable<IGroupPost> posts = reader.GetPosts().Cast<IGroupPost>().ToList();

                reader.Close();

                return posts;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public IEnumerable<IPost> GetPostsByUser(uint userId)
        {
            try
            {
                string query = "SELECT * FROM `post` WHERE `author_id`=@userId;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("userId", userId);

                MySqlDataReader reader = command.ExecuteReader();

                IEnumerable<IPost> posts = reader.GetPosts().ToList(); //Linq uses deferred execution, so this fixes things going out of scope

                
                reader.Close();

                return posts;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public void MarkAsEdited(uint id, bool edited = true)
        {
            try
            {
                string query = "UPDATE `post` SET `edited`=@edited WHERE `id`=@id;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("id", id);
                command.Parameters.AddWithValue("edited", edited);
                
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
