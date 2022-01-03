using System.Text;

// https://leetcode.com/problems/longest-happy-string/

var solution = new Solution2();
// Input: a = 1, b = 1, c = 7

// Output: "ccaccbcc" or "ccbccacc"
Console.WriteLine(solution.LongestDiverseString(1, 1, 7));

// Input: a = 7, b = 1, c = 0
// Output: "aabaa"
Console.WriteLine(solution.LongestDiverseString(7, 1, 0));

// Input: a = 1, b = 0, c = 0
// Output: "a"
Console.WriteLine(solution.LongestDiverseString(1, 0, 0));

// Input: a = 2, b = 2, c = 1
// Output: "aabbc"
Console.WriteLine(solution.LongestDiverseString(2, 2, 1));

// Input: a = 3, b = 0, c = 4
// Output: "ccaacca"
Console.WriteLine(solution.LongestDiverseString(3, 0, 4));

// Input: a = 0, b = 8, c = 11
// Output: "ccbccbbccbbccbbccbc"
Console.WriteLine(solution.LongestDiverseString(0, 8, 11));

// Input: a = 2, b = 8, c = 10
// Output: "ccbbccbbccbbccaabbcc"
Console.WriteLine(solution.LongestDiverseString(2, 8, 10));

/// <summary>
/// From leetcode, with priority queue
/// </summary>
public class Solution
{
    public string LongestDiverseString(int a, int b, int c)
    {
        PriorityQueue<Pair, int> queue = new PriorityQueue<Pair, int>();
        if (a > 0)
            queue.Enqueue(new Pair('a', a), a * (-1));

        if (b > 0)
            queue.Enqueue(new Pair('b', b), b * (-1));

        if (c > 0)
            queue.Enqueue(new Pair('c', c), c * (-1));

        StringBuilder sb = new StringBuilder();
        char last = 'x';
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (current.Char == last)
            {
                if (queue.Count == 0)
                    return sb.ToString();

                var next = queue.Dequeue();
                sb.Append(next.Char);
                next.Count--;
                if (next.Count > 0)
                    queue.Enqueue(next, next.Count * (-1));

                queue.Enqueue(current, current.Count * (-1));
                last = next.Char;
            }
            else
            {
                if (current.Count >= 2)
                {
                    sb.Append(current.Char);
                    sb.Append(current.Char);
                    current.Count -= 2;
                    if (current.Count > 0)
                        queue.Enqueue(current, current.Count * (-1));
                }
                else
                {
                    sb.Append(current.Char);
                }
                last = current.Char;
            }
        }
        return sb.ToString();
    }
    public class Pair
    {
        public char Char;
        public int Count;
        public Pair(char ch, int value)
        {
            Char = ch;
            Count = value;
        }
    }
}

/// <summary>
/// My solution, rewrote after I understood PriorityQueue solution.
/// In C# PriorityQueues appared in C# 10, but on Leetcode is C# 9.
/// So I understood the solution and rewrote mine.
/// </summary>
public class Solution2
{
    public string LongestDiverseString(int a, int b, int c)
    {
        var chars = new Dictionary<char, int>
        {
            { 'a', a },
            { 'b', b },
            { 'c', c }
        };

        var stringBuilding = new StringBuilder();
        var lastChar = ' ';
        while (true)
        {
            var max = GetMax(chars);
            if (max.Count == 0)
                break;

            if (max.Character != lastChar)
            {
                if (max.Count >= 2)
                {
                    stringBuilding.Append(max.Character);
                    stringBuilding.Append(max.Character);
                    chars[max.Character] -= 2;
                }
                else
                {
                    stringBuilding.Append(max.Character);
                    chars[max.Character] -= 1;
                }

                lastChar = max.Character;
            }
            else
            {
                var medium = GetMedium(chars, max);
                if (medium.Count == 0)
                    break;

                stringBuilding.Append(medium.Character);
                chars[medium.Character] -= 1;
                lastChar = medium.Character;
            }
        }

        return stringBuilding.ToString();
    }

    private Char GetMax(Dictionary<char, int> chars)
    {
        return chars
            .Select(x => new Char(x.Key, x.Value))
            .Max();
    }

    private Char GetMedium(Dictionary<char, int> chars, Char max)
    {
        var min = chars
            .Select(x => new Char(x.Key, x.Value))
            .Min();
        var medium = chars.First(x => x.Key != max.Character && x.Key != min.Character);
        return new Char(medium.Key, medium.Value);
    }

    private struct Char : IComparable<Char>
    {
        public Char(char value, int count)
        {
            Character = value;
            Count = count;
        }

        public char Character { get; set; }
        public int Count { get; set; }

        public int CompareTo(Char other)
        {
            return Count - other.Count;
        }
    }
}
