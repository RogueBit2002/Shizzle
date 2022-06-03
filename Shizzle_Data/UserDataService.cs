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
    public class UserDataService : IUserDataService
    {
        public IUser CreateUser(string name, string email, string password)
        {
            try
            {
                string query = @$"INSERT INTO `user`(`name`, `email`, `password`, `biography`) VALUES
    ('{name}', '{email}', '{password}', 'Hello there!');";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();

                return GetUser((uint) command.LastInsertedId);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void DeleteUser(uint id, string password)
        {
            throw new NotImplementedException();
        }

        
        public IUser GetUser(uint id)
        {
            try
            {
                string query = $"SELECT * FROM `user` WHERE `id`={id} LIMIT 1;";


                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                
                MySqlDataReader reader = command.ExecuteReader();

                IUser user = reader.GetUser();

                reader.Close();

                return user;

            } catch(MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }

        public IUser GetUser(string email)
        {
            try
            {
                string query = $"SELECT * FROM `user` WHERE `email`={email} LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                MySqlDataReader reader = command.ExecuteReader();

                IUser user = reader.GetUser();

                reader.Close();

                return user;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public void SetBiography(uint id, string biography)
        {
            try
            {
                string query = $"UPDATE `user` SET `biography`='{biography}' WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SetEmail(uint id, string email)
        {
            try
            {
                string query = $"UPDATE `user` SET `email`='{email}' WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SetName(uint id, string name)
        {
            try
            {
                string query = $"UPDATE `user` SET `name`='{name}' WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SetPassword(uint id, string password)
        {
            try
            {
                string query = $"UPDATE `user` SET `password`='{password}' WHERE `id`={id};";

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
