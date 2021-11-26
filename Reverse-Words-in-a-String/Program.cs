// https://leetcode.com/problems/reverse-words-in-a-string/

var solution = new Solution();

// Input: s = "the sky is blue"
// Output: "blue is sky the"
Console.WriteLine(solution.ReverseWords("the sky is blue"));

// Input: s = "  hello world  "
// Output: "world hello"
Console.WriteLine(solution.ReverseWords("  hello world  "));

// Input: s = "a good   example"
// Output: "example good a"
Console.WriteLine(solution.ReverseWords("a good   example"));

// Input: s = "  Bob    Loves  Alice   "
// Output: "Alice Loves Bob"
Console.WriteLine(solution.ReverseWords("  Bob    Loves  Alice   "));

// Input: s = "Alice does not even like bob"
// Output: "bob like even not does Alice"
Console.WriteLine(solution.ReverseWords("Alice does not even like bob"));

public class Solution
{
    public string ReverseWords(string s)
    {
        var words = s.Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var middleIndex = (words.Length - 1) / 2;
        for (var i = 0; i < words.Length; i++)
        {
            var indexFromEnd = words.Length - 1 - i;
            var temp = words[i];
            words[i] = words[indexFromEnd];
            words[indexFromEnd] = temp;
            if (i == middleIndex)
                break;
        }

        return string.Join(" ", words);
    }
}
