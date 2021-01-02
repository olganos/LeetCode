using System;

namespace TwoSum
{
    /// <summary>
    /// Given an array of integers nums and an integer target,
    /// return indices of the two numbers such that they add up to target.
    /// https://leetcode.com/problems/two-sum/solution/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // var solution = new SolutionArray();
            var solution = new SolutionDictionary();
            // var solution = new SolutionDictionaryOnePass();

            // Input: nums = [2, 7, 11, 15], target = 9
            // Output:[0,1]
            Console.WriteLine(string.Join(", ", solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9)));

            // Input: nums = [-2, 7, 11, 15], target = 9
            // Output:[0,2]
            Console.WriteLine(string.Join(", ", solution.TwoSum(new int[] { -2, 7, 11, 15 }, 9)));

            // Input: nums = [3, 3], target = 6
            // Output:[0,1]
            Console.WriteLine(string.Join(", ", solution.TwoSum(new int[] { 3, 3 }, 6)));
        }
    }
}
