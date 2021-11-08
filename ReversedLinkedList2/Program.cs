// https://leetcode.com/problems/reverse-linked-list-ii/
using Helpers;

var solution = new Solution();
var printer = new ListPrinter();

// Input: head = [1,2,3,4,5], left = 2, right = 4
// Output: [1,4,3,2,5]
var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
printer.Print(head);
printer.Print(solution.ReverseBetween(head, 2, 4));
Console.WriteLine();

// Input: head = [5], left = 1, right = 1
// Output:[5]
head = new ListNode(5);
printer.Print(head);
printer.Print(solution.ReverseBetween(head, 1, 1));
Console.WriteLine();

// Input: head = [3,5], left = 1, right = 1
// Output:[3,5]
head = new ListNode(3, new ListNode(5));
printer.Print(head);
printer.Print(solution.ReverseBetween(head, 1, 1));
Console.WriteLine();

// Input: head = [3,5], left = 1, right = 2
// Output:[5,3]
head = new ListNode(3, new ListNode(5));
printer.Print(head);
printer.Print(solution.ReverseBetween(head, 1, 2));
Console.WriteLine();

public class Solution
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var current = head;
        ListNode prev = null;
        ListNode nodeBeforeReversed = null;
        ListNode lastRevercedNode = null;
        var position = 0;
        while (position <= right + 1)
        {
            position++;

            if (position == left - 1)
            {
                nodeBeforeReversed = current;
            }

            if (position >= left && position <= right)
            {
                if (position == left)
                {
                    lastRevercedNode = current;
                }

                var tempNext = current.next;
                current.next = prev;
                prev = current;
                current = tempNext;

                continue;
            }

            if (position == right + 1)
            {
                if (nodeBeforeReversed == null)
                    head = prev;
                else
                    nodeBeforeReversed.next = prev;
                lastRevercedNode.next = current;
                break;
            }

            current = current.next;
        }

        return head;
    }
}