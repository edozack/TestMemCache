using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace testMemCache
{
    public class CacheByMicrosoft : IObjectCacheClient
    {        
        MemoryCache m_cache;

        public CacheByMicrosoft()
        {
            m_cache = new MemoryCache("be");
        }
        public object Get<T>(string key)
        {
            var val = m_cache.Get(key); ;
            if (val == null)
                return null;
            return (T)val;
        }

        public void Set<T>(string key, T value, CacheItemPolicy policy)
        {
            m_cache.Set(key, value, policy);            
        }

        public object Remove(string key)
        {
            m_cache.Remove(key);            
            return null;
        }
      
    }
}
