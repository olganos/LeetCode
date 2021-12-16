// https://leetcode.com/problems/rotate-list/
using Helpers;

var solution = new Solution();
var printer = new ListPrinter();

// Input: head = [1,2,3,4,5], k = 2
// Output: [4,5,1,2,3]
var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
printer.Print(head);
printer.Print(solution.RotateRight(head, 2));

// Input: head = [0,1,2], k = 4
// Output:[2,0,1]
head = new ListNode(0, new ListNode(1, new ListNode(2)));
printer.Print(head);
printer.Print(solution.RotateRight(head, 4));

// Input: head = [], k = 9
// Output:[]
head = null;
printer.Print(head);
printer.Print(solution.RotateRight(head, 9));

// Input: head = [5], k = 9
// Output:[5]
head = new ListNode(5);
printer.Print(head);
printer.Print(solution.RotateRight(head, 9));

// Input: head = [5], k = 0
// Output:[5]
head = new ListNode(5);
printer.Print(head);
printer.Print(solution.RotateRight(head, 0));


public class Solution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        // the simplest case
        if (head?.next == null || k == 0)
            return head;

        var listWithIndices = new Dictionary<int, ListNode>();

        // Iterate via the list and save each node in a hash table
        // by their index, starting with 1        
        var current = head;
        var lastIndex = 0;
        while (current != null)
        {
            lastIndex++;
            listWithIndices[lastIndex] = current;
            current = current.next;
        }

        // Find the ammount of rotation steps
        var stepsCount = k % lastIndex;

        // Rotate
        while (stepsCount != 0)
        {
            listWithIndices[lastIndex - 1].next = null;
            listWithIndices[lastIndex].next = head;
            head = listWithIndices[lastIndex];
            stepsCount--;
            lastIndex--;
        }

        return head;
    }
}