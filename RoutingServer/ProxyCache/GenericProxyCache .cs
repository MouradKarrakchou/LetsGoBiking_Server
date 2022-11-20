﻿using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace ProxyCache
{
    internal class GenericProxyCache<T> where T : new()
    {
        public DateTimeOffset dt_default = ObjectCache.InfiniteAbsoluteExpiration;
        Dictionary<string, T> dict = new Dictionary<string, T>();
        DateTimeOffset expirationTime = DateTimeOffset.Now.AddMinutes(1);

        public T Get(string CacheItemName) {
            return get(CacheItemName, dt_default);

        }
        public T Get(string CacheItemName, double dt_seconds) {
            DateTimeOffset dt = DateTime.Now.AddSeconds(dt_seconds); //In this case, the Expiration Time is "dt_default"
            return get(CacheItemName, dt);

        }
        public T Get(string CacheItemName, DateTimeOffset dt) {
             return get(CacheItemName, dt);
        }

        private T get(string CacheItemName, DateTimeOffset dt)
        {
            T value;
            bool res = dict.TryGetValue(CacheItemName, out value);
            if (res == false || value == null)
            {//  If CacheItemName doesn't exist or has a null content 
                value = new T();//then create a new T object
                dict.Add(CacheItemName, value); // and put it in the cache
                expirationTime = dt; //In this case, the Expiration Time is <dt>
            }
            return value;
        }

        internal T UseCache(string CacheItemName)
        {
            ObjectCache cache = MemoryCache.Default;
            string fileContents = cache[CacheItemName] as string;
            if (fileContents == null)
            {
                new JCDecauxItem<T>("CacheItemName");
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10.0);

                cache.Set(CacheItemName, str, policy);

            }
            fileContents = cache[CacheItemName] as string;
            return (fileContents);
        }


    }
}