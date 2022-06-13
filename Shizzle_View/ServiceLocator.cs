using Shizzle.ILogic;
using System.Collections.Generic;

namespace Shizzle.View
{
    public static class ServiceLocator
    {
        private static HashSet<ISecureService> services = new HashSet<ISecureService>();
        
        public static void AddService(ISecureService service)
        {
            services.Add(service);
        }

        public static T Locate<T>() where T : class
        {
            foreach (ISecureService service in services)
                if (service is T)
                    return service as T;

            return null;
        }

        public static bool RemoveService(ISecureService service)
        {
            return services.Remove(service);
        }

        public static void Clear()
        {
            services.Clear();
        }

        public static void SetAuthorityId(uint id)
        {
            foreach(ISecureService service in services)
            {
                service.authorityId = id;
            }
        }
    }
}
