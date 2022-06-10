﻿using MySql.Data.MySqlClient;
using Shizzle.IData;
using Shizzle.Structures.LowLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    public class CommentDataService : ICommentDataService
    {
        public IComment CreateComment(string content, uint postId, uint authorId)
        {
            try
            {
                string query = @"INSERT INTO `comment`(`content`, `post_id`, `author_id`) VALUES
    (@content, @postId, @authorId);";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("content", content);
                command.Parameters.AddWithValue("postId", postId);
                command.Parameters.AddWithValue("authorId", authorId);

                command.ExecuteNonQuery();

                return GetComment((uint)command.LastInsertedId);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public void DeleteComment(uint id)
        {
            try
            {
                string query = "UPDATE `comment` SET `deleted`=1 WHERE `id`=@id;";

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
                string query = "UPDATE `comment` SET `content`=@content WHERE `id`=@id;";

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

        public IComment GetComment(uint id)
        {
            try
            {
                string query = "SELECT * FROM `comment` WHERE `id`=@id LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());
                command.Parameters.AddWithValue("id", id);

                MySqlDataReader reader = command.ExecuteReader();

                IComment comment = reader.GetComment();

                reader.Close();

                return comment;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IEnumerable<IComment> GetCommentsByPost(uint postId)
        {
            try
            {
                string query = "SELECT * FROM `comment` WHERE `post_id`=@postId;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("postId", postId);

                MySqlDataReader reader = command.ExecuteReader();

                

                IEnumerable<IComment> comments = reader.GetComments().ToList();

                reader.Close();

                return comments;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IEnumerable<IComment> GetCommentsByUser(uint userId)
        {
            try
            {
                string query = "SELECT * FROM `comment` WHERE `author_id`=@userId;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("userId", userId);

                MySqlDataReader reader = command.ExecuteReader();

                IEnumerable<IComment> comments = reader.GetComments().ToList();

                reader.Close();

                return comments;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void MarkAsEdited(uint id, bool edited = true)
        {
            try
            {
                string query = "UPDATE `comment` SET `edited`=@edited WHERE `id`=@id;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.Parameters.AddWithValue("edited", edited);
                command.Parameters.AddWithValue("id", id);
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
