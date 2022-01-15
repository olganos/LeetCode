// https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/

var solution = new Solution();

// Input: "aab"
// Output: 0
Console.WriteLine(solution.MinDeletions("aab"));

// Input: "aaabbbcc"
// Output: 2
Console.WriteLine(solution.MinDeletions("aaabbbcc"));

// Input: "ceabaacb"
// Output: 2
Console.WriteLine(solution.MinDeletions("ceabaacb"));

// Input: "c"
// Output: 0
Console.WriteLine(solution.MinDeletions("c"));

public class Solution
{
    public int MinDeletions(string s)
    {
        var charFrequencies = new Dictionary<char, int>();
        foreach (var ch in s)
        {
            if (charFrequencies.ContainsKey(ch))
            {
                charFrequencies[ch] += 1;
            }
            else
            {
                charFrequencies[ch] = 1;
            }
        }

        var toDelete = 0;
        var frequencyCount = new HashSet<int>();
        foreach (var charFrequency in charFrequencies)
        {
            var frequency = charFrequency.Value;
            if (frequencyCount.Contains(frequency))
            {
                for (var reducedFrequency = frequency - 1; reducedFrequency >= 0; reducedFrequency--)
                {
                    toDelete++;
                    if (!frequencyCount.Contains(reducedFrequency))
                    {
                        frequencyCount.Add(reducedFrequency);
                        break;
                    }
                }
            }
            else
            {
                frequencyCount.Add(frequency);
            }
        }

        return toDelete;
    }
}
