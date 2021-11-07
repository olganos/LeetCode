// https://leetcode.com/problems/reverse-linked-list/submissions/
var solution = new Solution();
var printer = new ListPrinter();

// Input: head = [1,2,3,4,5]
// Output: [5,4,3,2,1]
var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
printer.Print(head);    
printer.Print(solution.ReverseList(head));

// Input: head = [1,2]
// Output:[2,1]
head = new ListNode(1, new ListNode(2));
printer.Print(head);
printer.Print(solution.ReverseList(head));

// Input: head = []
// Output:[]
head = null;
printer.Print(head);    
printer.Print(solution.ReverseList(head));

public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode newHead = null;
        ListNode next;
        var current = head;

        while (current != null)
        {
            next = current.next;
            current.next = newHead;
            newHead = current;
            current = next;
        }

        return newHead;
    }
}

// Definition for singly - linked list.
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

public class ListPrinter
{
    public void Print(ListNode head)
    {
        var values = new List<int>();

        var current = head;
        while (current != null)
        {
            values.Add(current.val);    
            current = current.next;
        }

        Console.WriteLine(string.Join(", ", values));
    }
}