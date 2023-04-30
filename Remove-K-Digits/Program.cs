// https://leetcode.com/problems/remove-k-digits/

var solution = new Solution();

// Input: num = "1432219", k = 3
// Output: "1219"
Console.WriteLine(solution.RemoveKdigits("1432219", 3));
Console.WriteLine(solution.RemoveKdigitsSimple("1432219", 3));

// Input: num = "1402219", k = 3
// Output: "1019"
Console.WriteLine(solution.RemoveKdigits("1402219", 3));
Console.WriteLine(solution.RemoveKdigitsSimple("1402219", 3));

// Input: num = "10200", k = 1
// Output: "200"
Console.WriteLine(solution.RemoveKdigits("10200", 1));
Console.WriteLine(solution.RemoveKdigitsSimple("10200", 1));

// Input: num = "10", k = 2
// Output: "0"
Console.WriteLine(solution.RemoveKdigits("10", 2));
Console.WriteLine(solution.RemoveKdigitsSimple("10", 2));

public class Solution
{

    //This algorithm uses a stack to keep track of the digits and a count to keep track of how many digits have been removed so far.
    //We iterate through the digits in num and for each digit, we compare it with the top of the stack.
    //If the current digit is less than the top of the stack and we still have digits to remove,
    //we pop the stack and increment the count. Otherwise, we push the current digit onto the stack.

    //After iterating through all the digits in num, we remove any remaining digits from
    //the stack until we have removed k digits in total. We then convert the remaining digits in the stack
    //into a string and remove any leading zeros. If the resulting string is empty, we return "0".

    //This algorithm runs in O(n) time, where n is the length of num, and uses O(n) extra space for the stack.

    public string RemoveKdigits(string num, int k)
    {
        if (num.Length == k)
        {
            return "0";
        }

        Stack<char> stack = new Stack<char>();
        int count = 0;

        for (int i = 0; i < num.Length; i++)
        {
            while (stack.Count > 0 && num[i] < stack.Peek() && count < k)
            {
                stack.Pop();
                count++;
            }
            stack.Push(num[i]);
        }

        while (count < k)
        {
            stack.Pop();
            count++;
        }

        char[] chars = new char[stack.Count];
        int index = stack.Count - 1;

        while (stack.Count > 0)
        {
            chars[index--] = stack.Pop();
        }

        string result = new string(chars);
        int startIndex = 0;

        while (startIndex < result.Length && result[startIndex] == '0')
        {
            startIndex++;
        }

        if (startIndex == result.Length)
        {
            return "0";
        }

        return result.Substring(startIndex);
    }

    /// <summary>
    /// Brute force approach. Remove the biggest numbers from the beginning
    /// </summary>
    /// <param name="num"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    public string RemoveKdigitsSimple(string num, int k)
    {
        while (k > 0)
        {
            int n = num.Length;
            int i = 0;
            while (i + 1 < n && num[i] <= num[i + 1]) i++;
            num = num.Remove(i, 1);
            k--;
        }
        // trim leading zeros
        int s = 0;
        while (s < (int)num.Length - 1 && num[s] == '0') s++;
        num = num.Remove(0, s);

        return num == "" ? "0" : num;
    }
}