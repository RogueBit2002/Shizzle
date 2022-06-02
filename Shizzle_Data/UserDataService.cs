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
            throw new NotImplementedException();
        }

        public void DeleteUser(int id, string password)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(int id)
        {
            try
            {
                string query = $"SELECT * FROM `user` WHERE `id`={id} LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                MySqlDataReader reader = command.ExecuteReader();

                if (!reader.Read())
                    return null;

                User user = new User(
                    reader.GetInt32("id"),
                    reader.GetString("name"),
                    reader.GetString("email"),
                    reader.GetString("password"),
                    reader.GetString("biography"));

                return user;

            } catch(MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
            
        }

        public IUser GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public void SetBiography(int id, string biography)
        {
            throw new NotImplementedException();
        }

        public void SetEmail(int id, string email)
        {
            throw new NotImplementedException();
        }

        public void SetName(int id, string name)
        {
            throw new NotImplementedException();
        }

        public void SetPassword(int id, string password)
        {
            throw new NotImplementedException();
        }

        public bool TryLogin(int id, string password)
        {
            throw new NotImplementedException();
        }
    }
}
