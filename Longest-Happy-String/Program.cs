using System.Text;
using System.Collections.Generic;

// https://leetcode.com/problems/longest-happy-string/

var solution = new Solution();
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
Console.WriteLine(new Solution2().LongestDiverseString(0, 8, 11));

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
/// My, wrong solution
/// </summary>
public class Solution2
{
    public string LongestDiverseString(int a, int b, int c)
    {
        var chars = new Char[] {
            new Char('a', a),
            new Char('b', b),
            new Char('c', c) ,
        };

        var max = GetMax(a, b, c);
        var min = GetMin(a, b, c);
        var medium = GetMedium(chars, min, max);

        var stringBuilding = new StringBuilder();
        var lastChar = ' ';
        var next = medium;

        while (true)
        {
            if (max.Value == 0 && min.Value == 0 && medium.Value == 0)
                break;
            if (lastChar == max.Key)
                break;

            if (max.Value != 0)
            {
                stringBuilding.Append(max.Key);
                max.Value--;
                if (max.Value != 0)
                {
                    stringBuilding.Append(max.Key);
                    max.Value--;
                }
            }

            lastChar = max.Key;

            if (next.Key == medium.Key && medium.Value != 0)
            {
                stringBuilding.Append(medium.Key);
                medium.Value--;
                if (medium.Value != 0)
                {
                    stringBuilding.Append(medium.Key);
                    medium.Value--;
                }

                next = min.Value != 0 ? min : medium;
                lastChar = medium.Key;
                continue;
            }

            if (next.Key == min.Key && min.Value != 0)
            {
                stringBuilding.Append(min.Key);
                min.Value--;
                if (min.Value != 0)
                {
                    stringBuilding.Append(min.Key);
                    min.Value--;
                }

                next = medium.Value != 0 ? medium : min;
                lastChar = min.Key;
                continue;
            }
        }

        return stringBuilding.ToString();
    }

    private Char GetMax(int a, int b, int c)
    {
        var max = new Char('a', a);
        if (max.Value < b)
        {
            max = new Char('b', b);
        }

        if (max.Value < c)
        {
            max = new Char('c', c);
        }

        return max;
    }

    private Char GetMin(int a, int b, int c)
    {
        var min = new Char('a', a);
        if (min.Value > b)
        {
            min = new Char('b', b);
        }

        if (min.Value > c)
        {
            min = new Char('c', c);
        }

        return min;
    }

    private Char GetMedium(Char[] chars, Char min, Char max)
    {
        return chars.First(x => x.Key != max.Key && x.Key != min.Key);
    }

    private struct Char
    {
        public Char(char value, int count)
        {
            Key = value;
            Value = count;
        }

        public char Key { get; set; }
        public int Value { get; set; }
    }
}
