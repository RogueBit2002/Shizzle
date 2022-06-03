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
            throw new NotImplementedException();
        }

        public IGroup CreateGroup(string name, string dscription)
        {
            throw new NotImplementedException();
        }

        public void DeleteGroup(uint id)
        {
            throw new NotImplementedException();
        }

        public IGroup GetGroup(uint id)
        {
            uint[] GetMembers(uint id)
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

            uint[] GetAdmins(uint id)
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

        public IEnumerable<IGroup> GetGroupsByUserParticipation(uint userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAdmin(uint id, uint adminId)
        {
            throw new NotImplementedException();
        }

        public void SetDescription(uint id, string description)
        {
            throw new NotImplementedException();
        }

        public void SetName(uint id, string name)
        {
            throw new NotImplementedException();
        }

        public void SetOwner(uint id, uint ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
