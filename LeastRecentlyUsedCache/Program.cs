using System;
using System.Collections.Generic;

namespace LeastRecentlyUsedCache
{
    /// <summary>
    /// https://leetcode.com/problems/lru-cache/
    /// НЕ поняла из описания, как должно быть. Моя реализация не прошла тесты, Чужая прошла.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var lRUCache = new LRUCache2(2);
            lRUCache.Put(1, 1); // cache is {1=1}
            Console.WriteLine("null");

            lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            Console.WriteLine("null");

            lRUCache.Get(1);    // return 1
            Console.WriteLine(lRUCache.Get(1));

            lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            Console.WriteLine("null");

            lRUCache.Get(2);    // returns -1 (not found)
            Console.WriteLine(lRUCache.Get(2));

            lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            Console.WriteLine("null");

            lRUCache.Get(9);    // return -1 (not found)
            Console.WriteLine(lRUCache.Get(9));

            lRUCache.Get(3);    // return 3
            Console.WriteLine(lRUCache.Get(3));

            lRUCache.Get(4);    // return 4
            Console.WriteLine(lRUCache.Get(4));

            Console.ReadKey();
        }
    }

    /// <summary>
    /// Моя реализация
    /// </summary>
    public class LRUCache
    {

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _cache = new Dictionary<int, int>();
            _currentlyUsed = new Stack<int>();
        }

        public int Get(int key)
        {
            if (key < 0 || key > 3000)
                return _notFound;

            if (_cache.ContainsKey(key))
                return _cache[key];

            return _notFound;
        }

        public void Put(int key, int value)
        {
            if (_capacity == _cache.Count)
            {
                _cache.Remove(_currentlyUsed.Pop());
                _cache[key] = value;
                return;
            }

            if (!_cache.ContainsKey(key))
                _currentlyUsed.Push(key);

            _cache[key] = value;
        }

        private int _capacity;
        private Stack<int> _currentlyUsed;
        private Dictionary<int, int> _cache;

        private int _notFound = -1;
    }

    /// <summary>
    /// Чужая реализация, медленная
    /// </summary>
    public class LRUCache2
    {

        private int capacity;
        private Dictionary<int, int> dic;
        private LinkedList<int> cacheList;

        public LRUCache2(int capacity)
        {
            this.capacity = capacity;
            dic = new Dictionary<int, int>();
            cacheList = new LinkedList<int>();
        }

        public int Get(int key)
        {
            if (!dic.ContainsKey(key))
                return -1;

            cacheList.Remove(key);
            cacheList.AddFirst(key);
            return dic[key];
        }

        public void Put(int key, int value)
        {
            if (dic.ContainsKey(key))
            {
                // update the value of cache
                dic[key] = value;

                // re-arrange the order of cacheList
                cacheList.Remove(key);
                cacheList.AddFirst(key);
            }
            else
            {
                if (dic.Count >= capacity)
                {
                    dic.Remove(cacheList.Last.Value);
                    cacheList.RemoveLast();
                }

                // add cache
                dic.Add(key, value);
                cacheList.AddFirst(key);
            }
        }
    }
}
