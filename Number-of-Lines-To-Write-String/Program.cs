//https://leetcode.com/problems/number-of-lines-to-write-string/

var solution = new Solution();

// Input:
// widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10],
// s = "abcdefghijklmnopqrstuvwxyz"

// Output: [3,60]
Console.WriteLine(string.Join(", ", solution.NumberOfLines(
    new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 },
    "abcdefghijklmnopqrstuvwxyz")));

// Input:
// widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10],
// s = "bbbcccdddaaa"

// Output: [2,4]
Console.WriteLine(string.Join(", ", solution.NumberOfLines(
    new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 },
    "bbbcccdddaaa")));

public class Solution
{

    private const int LINE_WIDTH = 100;

    private const int CHAR_DIFF = 97;

    public int[] NumberOfLines(int[] widths, string s)
    {
        if (s.Length == 0)
            return new int[2] { 0, 0 };

        var currentLineLength = 0;
        var lines = 1;
        for (var i = 0; i < s.Length; i++)
        {
            var letter = s[i];
            var tempLineLength = currentLineLength + widths[letter - CHAR_DIFF];
            if (tempLineLength < LINE_WIDTH)
            {
                currentLineLength = tempLineLength;
                continue;
            }
            
            if (tempLineLength > LINE_WIDTH)
            {
                lines++;
                currentLineLength = widths[letter - CHAR_DIFF];
                continue;
            }

            // if tempLineLength == LINE_WIDTH

            // if next letter exists
            if (i + 1 < s.Length)
            {
                currentLineLength = 0;
                lines++;
                continue;
            }

            currentLineLength = tempLineLength;
        }

        return new int[] { lines, currentLineLength };
    }
}
