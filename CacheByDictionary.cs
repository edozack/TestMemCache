using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace testMemCache
{
    public class CacheByDictionary : IObjectCacheClient
    {
        static HashSet<string> keys = new HashSet<string>();

        ConcurrentDictionary<string, object> m_cache;

        public CacheByDictionary()
        {
            m_cache = new ConcurrentDictionary<string, object>();
        }
        public object Get<T>(string key)
        {
            object val;
            m_cache.TryGetValue(key, out val);

            if (val == null)
                return null;
            return (T)val;
        }

        public void Set<T>(string key, T value, CacheItemPolicy policy)
        {
            m_cache[key] = value;
        }

        public object Remove(string key)
        {
            object val;
            m_cache.TryRemove(key, out val);
            return null;
        }    
    }

}
