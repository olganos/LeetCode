using System;
using System.Collections.Generic;

namespace Implement_Queue_using_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://leetcode.com/problems/implement-queue-using-stacks/
            MyQueue myQueue = new MyQueue();
            myQueue.Push(1); // queue is: [1]
            myQueue.Push(2); // queue is: [1, 2] (leftmost is front of the queue)
            myQueue.Peek(); // return 1
            myQueue.Pop(); // return 1, queue is [2]
            myQueue.Empty(); // return false
        }

        /// <summary>
        /// Implemented with two stacks.
        /// Add items in the first and the first time when Pop or Peek invokes,
        /// reverse the first stack into the second one and Pop or Peek from the second stack.
        /// When the second stack is empty, repeat
        /// </summary>
        public class MyQueue
        {
            private Stack<int> _inStack;
            private Stack<int> _outStack;

            /** Initialize your data structure here. */
            public MyQueue()
            {
                _inStack = new Stack<int>();
                _outStack = new Stack<int>();
            }

            /** Push element x to the back of queue. */
            public void Push(int x)
            {
                _inStack.Push(x);
            }

            /** Removes the element from in front of queue and returns that element. */
            public int Pop()
            {
                if (_outStack.Count == 0)
                {
                    ReverseStacks();
                }

                return _outStack.Pop();
            }

            /** Get the front element. */
            public int Peek()
            {
                if (_outStack.Count == 0)
                {
                    ReverseStacks();
                }

                return _outStack.Peek();
            }

            /** Returns whether the queue is empty. */
            public bool Empty()
            {
                return _inStack.Count == 0 && _outStack.Count == 0;
            }

            private void ReverseStacks()
            {
                while (_inStack.Count != 0)
                {
                    _outStack.Push(_inStack.Pop());
                }
            }
        }
    }
}
