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
    public class GroupDataService : IGroupDataService
    {
        public void AddAdmin(uint id, uint adminId)
        {
            try
            {
                string query = @$"INSERT INTO `group_admin_link`(`group_id`, `admin_id`) VALUES
    ({id}, {adminId});";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public IGroup CreateGroup(string name, string description, uint ownerId)
        {
            try
            {
                string query = @$"INSERT INTO `group`(`name`, `description`, `owner_id`) VALUES
    ('{name}', '{description}', {ownerId});";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();

                return GetGroup((uint)command.LastInsertedId);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public void DeleteGroup(uint id)
        {
            try
            {
                string query = $"UPDATE `group` SET `deleted`=1 WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private uint[] GetMembers(uint id)
        {
            string query = $"SELECT * FROM `group_member_link` WHERE `group_id`={id};";

            MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<uint> ids = new List<uint>();
            while (reader.Read())
            {
                ids.Add(reader.GetUInt32("member_id"));
            }

            reader.Close();

            return ids.ToArray();
        }

        private uint[] GetAdmins(uint id)
        {
            string query = $"SELECT * FROM `group_admin_link` WHERE `group_id`={id};";

            MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

            MySqlDataReader reader = command.ExecuteReader();

            List<uint> ids = new List<uint>();
            while (reader.Read())
            {
                ids.Add(reader.GetUInt32("admin_id"));
            }

            reader.Close();

            return ids.ToArray();
        }


        public IGroup GetGroup(uint id)
        {
            
            
            try
            {
                string query = $"SELECT * FROM `group` WHERE `id`={id} LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());


                MySqlDataReader reader = command.ExecuteReader();

                Group group = reader.GetGroup();

                reader.Close();

                if (group == null)
                    return null;

                group.memberIds = GetMembers(id);
                group.adminIds = GetAdmins(id);


                return group;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IGroup GetGroup(string name)
        {
            try
            {
                string query = $"SELECT * FROM `group` WHERE `name`='{name}' LIMIT 1;";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());


                MySqlDataReader reader = command.ExecuteReader();

                Group group = reader.GetGroup();

                reader.Close();

                if (group == null)
                    return null;

                group.memberIds = GetMembers(group.id);
                group.adminIds = GetAdmins(group.id);


                return group;

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public IEnumerable<IGroup> GetGroupsByUserParticipation(uint userId)
        {
            try
            {
                string query = $@"SELECT * FROM `group` WHERE `id` IN (SELECT `group_id` FROM `group_member_link` WHERE `member_id`={userId});";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                MySqlDataReader reader = command.ExecuteReader();

                IEnumerable<IGroup> groups = reader.GetGroups();

                reader.Close();

                return groups;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public void RemoveAdmin(uint id, uint adminId)
        {
            try
            {
                string query = $"DELETE FROM `post` WHERE `group_id`={id} AND `admin_id`={adminId};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void SetDescription(uint id, string description)
        {
            try
            {
                string query = $"UPDATE `post` SET `description`={description} WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*public void SetName(uint id, string name)
        {
            try
            {
                string query = $"UPDATE `post` SET `name`={name} WHERE `id`={id};";

                MySqlCommand command = new MySqlCommand(query, DatabaseConnectionProvider.GetConnection());

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }*/

        public void SetOwner(uint id, uint ownerId)
        {
            try
            {
                string query = $"UPDATE `post` SET `owner_id`={ownerId} WHERE `id`={id};";

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
