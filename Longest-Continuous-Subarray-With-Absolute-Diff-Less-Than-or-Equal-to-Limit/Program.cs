using System;

namespace Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit
{
    /// <summary>
    /// https://leetcode.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // var solution = new SolutionThreeLoops();
            var solution = new SolutionSlidingWindow();
            // Input: nums = [8,2,4,7], limit = 4
            // Output: 2
            Console.WriteLine(solution.LongestSubarray(new[] { 8, 2, 4, 7 }, 4));

            // Input: nums = [10,1,2,4,7,2], limit = 5
            // Output: 4
            Console.WriteLine(solution.LongestSubarray(new[] { 10, 1, 2, 4, 7, 2 }, 5));

            // Input: nums = [4,2,2,2,4,4,2,2], limit = 0
            // Output: 3
            Console.WriteLine(solution.LongestSubarray(new[] { 4, 2, 2, 2, 4, 4, 2, 2 }, 0));

            // Input: nums = [1,5,6,7,8,10,6,5,6], limit = 4
            // Output: 5
            Console.WriteLine(solution.LongestSubarray(new[] { 1, 5, 6, 7, 8, 10, 6, 5, 6 }, 4));

            // Input: nums = [9,10,1,7,9,3,9,9], limit = 7
            // Output: 5
            Console.WriteLine(solution.LongestSubarray(new[] { 9, 10, 1, 7, 9, 3, 9, 9 }, 7));
        }
    }
}
