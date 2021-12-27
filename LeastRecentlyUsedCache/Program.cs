using System;
using System.Collections.Generic;

namespace LeastRecentlyUsedCache
{
    /// <summary>
    /// https://leetcode.com/problems/lru-cache/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //var lRUCache = new LRUCache(2);
            //lRUCache.Put(1, 1); // cache is {1=1}
            //Console.WriteLine("null");

            //lRUCache.Put(2, 2); // cache is {1=1, 2=2}
            //Console.WriteLine("null");

            //var get = lRUCache.Get(1);    // return 1
            //Console.WriteLine(get);

            //lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
            //Console.WriteLine("null");

            //get = lRUCache.Get(2);    // returns -1 (not found)
            //Console.WriteLine(get);

            //lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
            //Console.WriteLine("null");

            //get = lRUCache.Get(9);    // return -1 (not found)
            //Console.WriteLine(get);

            //get = lRUCache.Get(3);    // return 3
            //Console.WriteLine(get);

            //get = lRUCache.Get(4);    // return 4
            //Console.WriteLine(get);

            //Console.WriteLine();

            //lRUCache = new LRUCache(2);
            //// ["LRUCache","put","put","get","put","get","put","get","get","get"]
            //// [[2],[1,0],[2,2],[1],[3,3],[2],[4,4],[1],[3],[4]]
            //lRUCache.Put(1, 0);
            //Console.WriteLine("null");

            //lRUCache.Put(2, 2);
            //Console.WriteLine("null");

            //get = lRUCache.Get(1);    // return 0
            //Console.WriteLine(get);

            //lRUCache.Put(3, 3);
            //Console.WriteLine("null");

            //get = lRUCache.Get(2);    // returns -1 (not found)
            //Console.WriteLine(get);

            //lRUCache.Put(4, 4);
            //Console.WriteLine("null");

            //get = lRUCache.Get(1);    // return 0
            //Console.WriteLine(get);

            //get = lRUCache.Get(3);    // return 3
            //Console.WriteLine(get);

            //get = lRUCache.Get(4);    // return 4
            //Console.WriteLine(get);

            //Console.WriteLine();

            var lRUCache = new LRUCacheManualDLinkedList(10);
            // ["LRUCache","put","put","put","put","put","get","put","get","get","put","get","put","put","put","get","put","get","get","get","get","put","put","get","get","get","put","put","get","put","get","put","get","get","get","put","put","put","get","put","get","get","put","put","get","put","put","put","put","get","put","put","get","put","put","get","put","put","put","put","put","get","put","put","get","put","get","get","get","put","get","get","put","put","put","put","get","put","put","put","put","get","get","get","put","put","put","get","put","put","put","get","put","put","put","get","get","get","put","put","put","put","get","put","put","put","put","put","put","put"]
            // [[10],[10,13],[3,17],[6,11],[10,5],[9,10],[13],[2,19],[2],[3],[5,25],[8],[9,22],[5,5],[1,30],[11],[9,12],[7],[5],[8],[9],[4,30],[9,3],[9],[10],[10],[6,14],[3,1],[3],[10,11],[8],[2,14],[1],[5],[4],[11,4],[12,24],[5,18],[13],[7,23],[8],[12],[3,27],[2,12],[5],[2,9],[13,4],[8,18],[1,7],[6],[9,29],[8,21],[5],[6,30],[1,12],[10],[4,15],[7,22],[11,26],[8,17],[9,29],[5],[3,4],[11,30],[12],[4,29],[3],[9],[6],[3,4],[1],[10],[3,29],[10,28],[1,20],[11,13],[3],[3,12],[3,8],[10,9],[3,26],[8],[7],[5],[13,17],[2,27],[11,15],[12],[9,19],[2,15],[3,16],[1],[12,17],[9,1],[6,19],[4],[5],[5],[8,1],[11,7],[5,2],[9,28],[1],[2,2],[7,4],[4,22],[7,24],[9,26],[13,28],[11,26]]

            // [null,null,null,null,null,null,-1,null,19,17,null,-1,null,null,null,-1,null,-1,5,-1,12,null,null,3,5,5,null,null,1,null,-1,null,30,5,30,null,null,null,-1,null,-1,24,null,null,18,null,null,null,null,-1,null,null,18,null,null,-1,null,null,null,null,null,18,null,null,-1,null,4,29,30,null,12,-1,null,null,null,null,29,null,null,null,null,17,22,18,null,null,null,-1,null,null,null,20,null,null,null,-1,18,18,null,null,null,null,20,null,null,null,null,null,null,null]

            var expected = new int[]
            {
                -1,19,17,-1,-1,-1,5,-1,12,3,5,5,1,-1,30,5,30,-1,-1,24,18,-1,18,-1,18,-1,4,29,30,12,-1,29,17,22,18,-1,20,-1,18,18,20
            };
            var actual = new List<int>();

            lRUCache.Put(10, 13);
            lRUCache.Put(3, 17);
            lRUCache.Put(6, 11);
            lRUCache.Put(10, 5);
            lRUCache.Put(9, 10);

            actual.Add(lRUCache.Get(13)); // return -1

            lRUCache.Put(2, 19);

            actual.Add(lRUCache.Get(2)); // return 19
            actual.Add(lRUCache.Get(3)); // return 17

            lRUCache.Put(5, 25);

            actual.Add(lRUCache.Get(8)); // return -1

            lRUCache.Put(9, 22);
            lRUCache.Put(5, 5);
            lRUCache.Put(1, 30);

            actual.Add(lRUCache.Get(11)); // return -1

            lRUCache.Put(9, 12);

            actual.Add(lRUCache.Get(7)); // return -1
            actual.Add(lRUCache.Get(5)); // return 5
            actual.Add(lRUCache.Get(8)); // return -1
            actual.Add(lRUCache.Get(9)); // return 12

            lRUCache.Put(4, 30);
            lRUCache.Put(9, 3);

            actual.Add(lRUCache.Get(9)); // return 3
            actual.Add(lRUCache.Get(10)); // return 5
            actual.Add(lRUCache.Get(10)); // return 5

            lRUCache.Put(6, 14);
            lRUCache.Put(3, 1);

            actual.Add(lRUCache.Get(3)); // return 1

            lRUCache.Put(10, 11);

            actual.Add(lRUCache.Get(8)); // return -1

            lRUCache.Put(2, 14);

            actual.Add(lRUCache.Get(1)); // return 30
            actual.Add(lRUCache.Get(5)); // return 5
            actual.Add(lRUCache.Get(4)); // return 30

            lRUCache.Put(11, 4);
            lRUCache.Put(12, 24);
            lRUCache.Put(5, 18);

            actual.Add(lRUCache.Get(13)); // return -1

            lRUCache.Put(7, 23);

            actual.Add(lRUCache.Get(8)); // return -1
            actual.Add(lRUCache.Get(12)); // return 24

            lRUCache.Put(3, 27);
            lRUCache.Put(2, 12);

            actual.Add(lRUCache.Get(5)); // return 18

            lRUCache.Put(2, 9);
            lRUCache.Put(13, 4);
            lRUCache.Put(8, 18);
            lRUCache.Put(1, 7);

            actual.Add(lRUCache.Get(6)); // return -1

            lRUCache.Put(9, 29);
            lRUCache.Put(8, 21);

            actual.Add(lRUCache.Get(5)); // return 18

            lRUCache.Put(6, 30);
            lRUCache.Put(1, 12);

            actual.Add(lRUCache.Get(10)); // return -1

            lRUCache.Put(4, 15);
            lRUCache.Put(7, 22);
            lRUCache.Put(11, 26);
            lRUCache.Put(8, 17);
            lRUCache.Put(9, 29);

            actual.Add(lRUCache.Get(5)); // return 18

            lRUCache.Put(3, 4);
            lRUCache.Put(11, 30);

            actual.Add(lRUCache.Get(12)); // return -1

            lRUCache.Put(4, 29);

            actual.Add(lRUCache.Get(3)); // return 4
            actual.Add(lRUCache.Get(9)); // return 29
            actual.Add(lRUCache.Get(6)); // return 30

            lRUCache.Put(3, 4);

            actual.Add(lRUCache.Get(1)); // return 12
            actual.Add(lRUCache.Get(10)); // return -1

            lRUCache.Put(3, 29);
            lRUCache.Put(10, 28);
            lRUCache.Put(1, 20);
            lRUCache.Put(11, 13);

            actual.Add(lRUCache.Get(3)); // return 29

            lRUCache.Put(3, 12);
            lRUCache.Put(3, 8);
            lRUCache.Put(10, 9);
            lRUCache.Put(3, 26);

            actual.Add(lRUCache.Get(8)); // return 17
            actual.Add(lRUCache.Get(7)); // return 22
            actual.Add(lRUCache.Get(5)); // return 18

            lRUCache.Put(13, 17);
            lRUCache.Put(2, 27);
            lRUCache.Put(11, 15);

            actual.Add(lRUCache.Get(12)); // return -1

            lRUCache.Put(9, 19);
            lRUCache.Put(2, 15);
            lRUCache.Put(3, 16);

            actual.Add(lRUCache.Get(1)); // return 20

            lRUCache.Put(12, 17);
            lRUCache.Put(9, 1);
            lRUCache.Put(6, 19);

            actual.Add(lRUCache.Get(4)); // return -1
            actual.Add(lRUCache.Get(5)); // return 18
            actual.Add(lRUCache.Get(5)); // return 18

            lRUCache.Put(8, 1);
            lRUCache.Put(11, 7);
            lRUCache.Put(5, 2);
            lRUCache.Put(9, 28);

            actual.Add(lRUCache.Get(1)); // return 20

            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                    throw new Exception($"Expected {expected[i]}, found {actual[i]} at index {i}");
            }

            // ["LRUCache","get","get","put","get","put","put","put","put","get","put"]
            // [[1],[6],[8],[12,1],[2],[15,11],[5,2],[1,15],[4,2],[5],[15,15]]

            lRUCache = new LRUCacheManualDLinkedList(1);

            expected = new int[] { -1, -1, -1, -1 };
            actual = new List<int>();

            actual.Add(lRUCache.Get(6)); // return -1
            actual.Add(lRUCache.Get(8)); // return -1

            lRUCache.Put(12, 1);

            actual.Add(lRUCache.Get(2)); // return -1

            lRUCache.Put(15, 11);
            lRUCache.Put(5, 2);
            lRUCache.Put(1, 15);
            lRUCache.Put(4, 2);

            actual.Add(lRUCache.Get(5)); // return -1

            lRUCache.Put(15, 15);

            for (int i = 0; i < expected.Length; i++)
            {
                if (expected[i] != actual[i])
                    throw new Exception($"Expected {expected[i]}, found {actual[i]} at index {i}");
            }

        }
    }

    /// <summary>
    /// From leetcode
    /// </summary>
    public class LRUCache
    {

        class DLinkedNode
        {
            public int key;
            public int value;
            public DLinkedNode prev;
            public DLinkedNode next;
        }

        private void addNode(DLinkedNode node)
        {
            /**
             * Always add the new node right after head.
             */
            node.prev = head;
            node.next = head.next;

            head.next.prev = node;
            head.next = node;
        }

        private void removeNode(DLinkedNode node)
        {
            /**
             * Remove an existing node from the linked list.
             */
            DLinkedNode prev = node.prev;
            DLinkedNode next = node.next;

            prev.next = next;
            next.prev = prev;
        }

        private void moveToHead(DLinkedNode node)
        {
            /**
             * Move certain node in between to the head.
             */
            removeNode(node);
            addNode(node);
        }

        private DLinkedNode popTail()
        {
            /**
             * Pop the current tail.
             */
            DLinkedNode res = tail.prev;
            removeNode(res);
            return res;
        }

        private Dictionary<int, DLinkedNode> cache = new Dictionary<int, DLinkedNode>();
        private int size;
        private int capacity;
        private DLinkedNode head, tail;

        public LRUCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;

            head = new DLinkedNode();
            // head.prev = null;

            tail = new DLinkedNode();
            // tail.next = null;

            head.next = tail;
            tail.prev = head;
        }

        public int Get(int key)
        {
            cache.TryGetValue(key, out var node);
            if (node == null) return -1;

            // move the accessed node to the head;
            moveToHead(node);

            return node.value;
        }

        public void Put(int key, int value)
        {
            cache.TryGetValue(key, out var node);

            if (node == null)
            {
                DLinkedNode newNode = new DLinkedNode();
                newNode.key = key;
                newNode.value = value;

                cache.Add(key, newNode);
                addNode(newNode);

                ++size;

                if (size > capacity)
                {
                    // pop the tail
                    DLinkedNode tail = popTail();
                    cache.Remove(tail.key);
                    --size;
                }
            }
            else
            {
                // update the value.
                node.value = value;
                moveToHead(node);
            }
        }
    }
}
