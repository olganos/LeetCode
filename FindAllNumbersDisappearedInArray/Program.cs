using System;
using System.Collections.Generic;
using System.Linq;

namespace FindAllNumbersDisappearedInArray
{
    /// <summary>
    /// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // var solution = new SolutionExtraMemory();
            // var solution = new SolutionSameArray();
            var solution = new Solution();

            // Input: [4,3,2,7,8,2,3,1]
            // Output: [5,6]
            Console.WriteLine(string.Join(", ",
                solution.FindDisappearedNumbers(new[] { 4, 3, 2, 7, 8, 2, 3, 1 })));

            // Input: [4,3,2,2,3,1]
            // Output: [5,6]
            Console.WriteLine(string.Join(", ",
                solution.FindDisappearedNumbers(new[] { 4, 3, 2, 2, 3, 1 })));

            // Input: [2,1]
            // Output: []
            Console.WriteLine(string.Join(", ",
                solution.FindDisappearedNumbers(new[] { 2, 1 })));
        }
    }

    /// <summary>
    /// Not mine. Without extra space, O(1n)
    /// </summary>
    public class Solution
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] > 0)
                    nums[index] = -nums[index];
            }
            List<int> result = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > 0)
                    result.Add(i + 1);
            }
            return result;
        }
    }

    /// <summary>
    /// Seems is correct but too slow
    /// </summary>
    public class SolutionSameArray
    {
        private int[] _nums;

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            _nums = nums;
            var result = new List<int>();
            for (var i = 0; i < _nums.Length; i++)
            {
                if (_nums[i] == i + 1)
                    continue;

                while (_nums[i] != 0)
                {
                    Swap(_nums[i], i);
                }
            }

            for (var i = 0; i < _nums.Length; i++)
            {
                if (_nums[i] == 0)
                    result.Add(i + 1);
            }

            return result;
        }

        private void Swap(int number, int index)
        {

            if (_nums[index] == _nums[number - 1] && index != number - 1)
            {
                _nums[index] = 0;
                return;
            }
            _nums[index] = _nums[number - 1];
            _nums[number - 1] = number;
        }
    }

    public class SolutionExtraMemory
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            var secondArray = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == nums.Length)
                    secondArray[0] = nums[i];
                else
                    secondArray[nums[i]] = nums[i];
            }

            var result = new List<int>();
            for (var i = 0; i < secondArray.Length; i++)
            {
                if (secondArray[i] == 0)
                    result.Add(i == 0 ? secondArray.Length : i);
            }

            return result;
        }
    }
}
