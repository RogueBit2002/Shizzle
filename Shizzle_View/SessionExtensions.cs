using Microsoft.AspNetCore.Http;
using System;
using System.Text;

namespace Shizzle.View
{
    public static class SessionExtensions
    {

        public static void SetString(this ISession session, string key, string value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(value));
        }

        public static string GetString(this ISession session, string key)
        {
            byte[] data = session.Get(key);
            return data == null ? null : Encoding.UTF8.GetString(data);
        }

        /*public static bool Has(this ISession session, string key)
        {
            return session.Get(key) != null;
        }*/

        public static void SetInt32(this ISession session, string key, uint value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }
        
        public static int GetInt32(this ISession session, string key)
        {
            byte[] data = session.Get(key);
            return data == null ? 0 : BitConverter.ToInt32(data);
        }


        public static void SetUInt32(this ISession session, string key, uint value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static uint GetUInt32(this ISession session, string key)
        {
            byte[] data = session.Get(key);
            return data == null ? 0 : BitConverter.ToUInt32(data);   
        }
    }
}
