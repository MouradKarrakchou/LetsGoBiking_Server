using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace ProxyCache
{
    internal class GenericProxyCache<T> where T : class
    {
        public DateTimeOffset dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        Dictionary<string, T> dict = new Dictionary<string, T>();
        DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(1);


        public T Get(string CacheItemName) {
            return useCache(CacheItemName, dt_default);

        }
        public T Get(string CacheItemName, double dt_seconds) {
            DateTimeOffset dt = DateTime.Now.AddSeconds(dt_seconds); //In this case, the Expiration Time is "dt_default"
            return useCache(CacheItemName, dt);

        }
        public T Get(string CacheItemName, DateTimeOffset dt) {
             return useCache(CacheItemName, dt);
        }


        private T useCache(string CacheItemName, DateTimeOffset dt) 
        {
            ObjectCache cache = MemoryCache.Default;
            T fileContents = cache[CacheItemName] as T;
            JCDecauxItem<T> item;
            if (fileContents == null)
            {
                Console.WriteLine("updating cache");
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = dt;

                JcdecauxToolProxy jcdecauxTool = new JcdecauxToolProxy();

                item = new JCDecauxItem<T>(CacheItemName);
                cache.Add(CacheItemName, item, policy);
            }
            fileContents = cache[CacheItemName] as T;
            return (fileContents);
        }


    }
}
