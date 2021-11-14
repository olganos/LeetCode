// https://leetcode.com/problems/longest-absolute-file-path/

var solution = new Solution();

// Doesn't work locally, but works on Leetcode environment

// Input: input = "dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"
// Output: 20
Console.WriteLine(solution.LengthLongestPath(@"dir\n\tsubdir1\n\tsubdir2\n\t\tfile.ext"));

// Input: input = "dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"
// Output: 32
Console.WriteLine(solution.LengthLongestPath(@"dir\n\tsubdir1\n\t\tfile1.ext\n\t\tsubsubdir1\n\tsubdir2\n\t\tsubsubdir2\n\t\t\tfile2.ext"));

// Input: input = "a"
// Output: 0
Console.WriteLine(solution.LengthLongestPath("a"));

// Input: input = "file1.txt\nfile2.txt\nlongfile.txt"
// Output: 12
Console.WriteLine(solution.LengthLongestPath(@"file1.txt\nfile2.txt\nlongfile.txt"));

public class Solution
{
    public int LengthLongestPath(string input)
    {
        var lines = input.Split('\n');
        // save the length of path on each level plus '/'
        // key - level
        // value = length
        var levels = new Dictionary<int, int>();

        var maxPath = 0;
        foreach (var line in lines)
        {
            var currentLevel = 0;
            var previousLevel = currentLevel - 1;
            // check the level
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '\t')
                {
                    previousLevel = currentLevel;
                    currentLevel++;
                }
                else
                {
                    break;
                }
            }

            // check is it a file or not
            var isFile = false;
            for (var i = line.Length - 1; i > currentLevel; i--)
            {
                if (line[i] == '.')
                {
                    isFile = true;
                    break;
                }
            }

            if (isFile)
            {
                var pathLength = levels.ContainsKey(previousLevel)
                    ? levels[previousLevel] + line.Length - (currentLevel)
                    : line.Length;
                maxPath = maxPath < pathLength ? pathLength : maxPath;
                continue;
            }

            // + 1 here means plus '/'
            levels[currentLevel] = currentLevel == 0 ? line.Length + 1 : levels[previousLevel] + line.Length - currentLevel + 1;
        }

        return maxPath;
    }
}