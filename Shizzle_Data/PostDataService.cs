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
            throw new NotImplementedException();
        }

        public IPost CreatePost(string title, string content, uint authorId, uint groupId)
        {
            throw new NotImplementedException();
        }

        public void DeletePost(uint id)
        {
            throw new NotImplementedException();
        }

        public void EditContent(uint id, string content)
        {
            throw new NotImplementedException();
        }

        public void EditTitle(uint id, string title)
        {
            throw new NotImplementedException();
        }

        public IPost GetPost(uint id)
        {
            try
            {
                string query = $"SELECT * FROM `post` WHERE `id`={id} LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());


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

        public IEnumerable<IPost> GetPostsByGroup(uint groupId)
        {
            return null;
        }

        public IEnumerable<IPost> GetPostsByUser(uint userId)
        {
            throw new NotImplementedException();
        }

        public void MarkAsEdited(uint id, bool edited = true)
        {
            try
            {
                string query = $"UPDATE `post` SET `edited`='{edited}' WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
