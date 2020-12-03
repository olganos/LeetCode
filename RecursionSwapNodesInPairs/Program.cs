using System;
using System.Text;

namespace RecursionSwapNodesInPairs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input: head = [1,2,3,4]
            // Output:[2,1,4,3]
            var solution = new Solution();
            var lastNode = new ListNode(4);
            var thirdNode = new ListNode(3, lastNode);
            var secondNode = new ListNode(2, thirdNode);
            var head = new ListNode(1, secondNode);
            Console.WriteLine(ListToString(solution.SwapPairs(head)));
            Console.WriteLine();

            // Input: head = []
            // Output:[]
            Console.WriteLine(ListToString(solution.SwapPairs(null)));
            Console.WriteLine();

            // Input: head = [1]
            // Output:[1]
            var head1 = new ListNode(1, null);
            Console.WriteLine(ListToString(solution.SwapPairs(head1)));
            Console.WriteLine();

            // Input: head = [2,1,3]
            // Output:[1,2,3]
            var lastNode2 = new ListNode(3);
            var secondNode2 = new ListNode(1, lastNode2);
            var head2 = new ListNode(2, secondNode2);
            Console.WriteLine(ListToString(solution.SwapPairs(head2)));
            Console.WriteLine();
        }

        private static string ListToString(ListNode head)
        {
            var stringBuilder = new StringBuilder();
            while (head != null)
            {
                stringBuilder.Append($"{head.val} ");
                head = head.next;
            }

            return stringBuilder.ToString();
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
        public ListNode SwapPairs(ListNode head)
        {
            if (head?.next == null)
                return head;

            ListNode swapped = null;
            Traversing(ref swapped, head);

            return swapped;
        }

        private void Traversing(ref ListNode next, ListNode rest)
        {
            if (rest == null)
            {
                next.next = null;
                return;
            }
            if (rest.next == null)
            {
                next.next = rest;
                return;
            }

            var first = rest.next;
            var second = rest;
            rest = rest.next.next;
            second.next = null;

            first.next = second;

            if (next == null)
                next = first;
            else
                next.next = first;

            Traversing(ref second, rest);
        }
    }
}
