using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassTemplate.Objects
{
    internal class Cache
    {
        private static readonly Lazy<Cache> instance = new Lazy<Cache>(() => new Cache());
        private static object lockert = new object();
        private readonly Hashtable cache;

        private Cache()
        {
            cache = new Hashtable();
        }

        public static Cache Instance
        {
            get { return instance.Value; }
        }

        public T GetOrStore<T>(string key, Func<T> action, int maxDuration = -1) where T : class
        {
            var result = this.cache[key];

            if (result == null ||
                (maxDuration > 0 && DateTime.UtcNow > ((CacheItem)result).Time.AddSeconds(maxDuration)))
            {
                lock (lockert)
                {
                    if (result == null ||
                        (maxDuration > 0 && DateTime.UtcNow > ((CacheItem)result).Time.AddSeconds(maxDuration)))
                    {
                        var obj = action();
                        result = obj != null ? new CacheItem(obj) : new CacheItem(default(T));
                        this.cache[key] = result;
                    }
                }
            }

            if (result == null)
            {
                return default(T);
            }

            return (T)((CacheItem)result).StoredObject;
        }

        public void RemoveFromCache(string key)
        {
            if (this.cache.ContainsKey(key))
            {
                this.cache.Remove(key);
            }
        }
    }
}
