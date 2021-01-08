using System;
using System.Collections.Generic;
using System.Linq;

namespace Add_Two_Numbers
{
    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            // Input: l1 = [2, 4, 3], l2 = [5, 6, 4]
            // Output:[7,0,8]
            // Explanation: 342 + 465 = 807.
            var l1 = new ListNode(2, new ListNode(4, new ListNode(3)));
            var l2 = new ListNode(5, new ListNode(6, new ListNode(4)));
            Console.WriteLine(string.Join(", ", ListToList(solution.AddTwoNumbers(l1, l2))));

            // Input: l1 = [0], l2 = [0]
            // Output:[0]
            l1 = new ListNode(0);
            l2 = new ListNode(0);
            Console.WriteLine(string.Join(", ", ListToList(solution.AddTwoNumbers(l1, l2))));

            // Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
            // Output:[8,9,9,9,0,0,0,1]
            l1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
            l2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
            Console.WriteLine(string.Join(", ", ListToList(solution.AddTwoNumbers(l1, l2))));
        }

        private static List<int> ListToList(ListNode list)
        {
            var result = new List<int>();
            var current = list;
            while (current != null)
            {
                result.Add(current.val);
                current = current.next;
            }

            return result;
        }
    }

    /**
    * Definition for singly-linked list.
    */
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
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var currentL1 = l1;
            var currentL2 = l2;
            ListNode sum = null;
            ListNode last = null;
            var previousRest = 0;
            while (currentL1 != null || currentL2 != null)
            {
                var currentSum = (currentL1?.val ?? 0) + (currentL2?.val ?? 0) + previousRest;

                if (currentSum >= 10)
                {
                    previousRest = 1;
                    currentSum = currentSum - 10;
                }
                else
                    previousRest = 0;

                if (sum == null)
                {
                    last = new ListNode(currentSum);
                    sum = last;
                }
                else
                {
                    last.next = new ListNode(currentSum);
                    last = last.next;
                }

                currentL1 = currentL1?.next;
                currentL2 = currentL2?.next;
            }

            if (previousRest == 0) return sum;

            // if the code went here, last couldn't be equal null, 
            // because, in this case sum would be a two-digit number and we created last on the previous step
            last.next = new ListNode(previousRest);

            return sum;
        }
    }
}
