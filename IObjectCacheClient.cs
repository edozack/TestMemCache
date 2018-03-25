using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace testMemCache
{
    public interface IObjectCacheClient
    {
        object Get<T>(string key);
        void Set<T>(string key, T value, CacheItemPolicy policy);
        object Remove(string key);       
    }
}
