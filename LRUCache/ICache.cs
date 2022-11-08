using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
    public interface ICache<TKey, TValue>
    {
        bool TryGetValue(TKey key, out TValue value);
        void Put(TKey Key, TValue value);
    }
}
