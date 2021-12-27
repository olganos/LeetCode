using System.Collections.Specialized;

namespace LeastRecentlyUsedCache
{
    /// <summary>
    /// Clear, but slow. Didn't pass on leetcode
    /// </summary>
    public class LRUCacheOrderedDictionary
    {

        public int _capacity = 0;
        public OrderedDictionary cache;

        public LRUCacheOrderedDictionary(int capacity)
        {
            _capacity = capacity;
            cache = new OrderedDictionary(capacity);
        }

        public int Get(int key)
        {
            if (cache.Contains(key))
            {
                var value = cache[(object)key];
                cache.Remove(key);
                cache.Add(key, value);
                return (int)value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            // if contains key
            // delete the key and insert again
            if (cache.Contains(key))
            {
                cache.Remove(key);
                cache.Add(key, value);
                return;
            }

            // else 
            // check capacity
            // if equal
            // delete 0 index
            // insert the key
            if (cache.Count == _capacity)
            {
                cache.RemoveAt(0);
                cache.Add(key, value);
                return;
            }
            // else 
            // insert the key        
            cache.Add(key, value);

        }
    }
}
