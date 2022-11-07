using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LRUCache
{
    public class LRUCache<TKey, TValue> : ICache<TKey, TValue>
    {
        public LinkedList<KeyValuePair<TKey, TValue>> List;

        public Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>> Cache;

        private int Count => Cache.Count;

        private int Capacity = 0;

        public LRUCache(int capacity)
        {
            Capacity = capacity;

            List = new LinkedList<KeyValuePair<TKey, TValue>>();

            Cache = new Dictionary<TKey, LinkedListNode<KeyValuePair<TKey, TValue>>>(capacity);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (Cache.ContainsKey(key))
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> node = Cache[key];

                List.Remove(node);

                List.AddFirst(node);

                value = node.Value.Value;

                return true;
            }

            value = default;
            return false;
        }
        public void Put(TKey key, TValue value)
        {
            if (Cache.ContainsKey(key))
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> node = Cache[key];

                List.Remove(node);

                node.Value.Value = value;

                List.AddFirst(node);
            }
            else
            {
                var node = new KeyValuePair<TKey, TValue>(key, value);

                List.AddFirst(node);

                Cache[key] = List.First;
            }
        }
       
    }
}
