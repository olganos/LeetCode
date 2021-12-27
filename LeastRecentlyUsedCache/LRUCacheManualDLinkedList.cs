using System.Collections.Generic;

namespace LeastRecentlyUsedCache
{

    /// <summary>
    /// Wanted to continue my own solution
    /// </summary>
    public class LRUCacheManualDLinkedList
    {
        public int _capacity = 0;
        public Dictionary<int, Node> cache = new();
        public DLinkedList tracker = new();

        public LRUCacheManualDLinkedList(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            cache.TryGetValue(key, out var node);
            if (node == null)
                return -1;

            tracker.DeleteNode(node);
            tracker.AddTail(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            cache.TryGetValue(key, out var node);
            if (node != null)
            {
                tracker.DeleteNode(node);
            }

            if (tracker.Count == _capacity)
            {
                cache.Remove(tracker.Head.Key);
                tracker.DeleteHead();
            }

            var newValue = new Node(key, value);
            tracker.AddTail(newValue);
            cache[key] = newValue;
        }

        public class DLinkedList
        {
            public Node Head { get; set; }
            public Node Tail { get; set; }

            public int Count { get; set; }

            public void AddTail(Node newTail)
            {
                newTail.Prev = null;
                newTail.Next = null;

                if (Tail == null)
                {
                    Tail = newTail;
                    Head = newTail;
                }
                else
                {
                    Tail.Next = newTail;
                    newTail.Prev = Tail;
                    Tail = newTail;
                }

                Count++;
            }

            public void DeleteNode(Node nodeDelete)
            {
                if (Count == 0)
                    return;

                if (nodeDelete.Prev != null)
                {
                    nodeDelete.Prev.Next = nodeDelete.Next;
                }

                if (nodeDelete.Next != null)
                {
                    nodeDelete.Next.Prev = nodeDelete.Prev;
                }

                if (nodeDelete == Tail)
                {
                    Tail = nodeDelete.Prev;
                }

                if (nodeDelete == Head)
                {
                    Head = nodeDelete.Next;
                }

                Count--;
            }

            public void DeleteHead()
            {
                if (Count == 0)
                    return;

                Head = Head.Next;

                if (Head != null)
                    Head.Prev = null;
                else
                    Tail = null;

                Count--;
            }
        }

        public class Node
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}
