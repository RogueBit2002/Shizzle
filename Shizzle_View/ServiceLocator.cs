using System.Collections.Generic;

namespace Shizzle.View
{
    public static class ServiceLocator
    {
        private static HashSet<object> services = new HashSet<object>();
        
        public static void AddService(object service)
        {
            services.Add(service);
        }

        public static T Locate<T>() where T : class
        {
            foreach (object service in services)
                if (service is T)
                    return service as T;

            return null;
        }

        public static bool RemoveService(object service)
        {
            return services.Remove(service);
        }

        public static void Clear()
        {
            services.Clear();
        }
    }
}
