namespace Helpers
{
    /// <summary>
    /// Class for printing a linked list
    /// </summary>
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
}