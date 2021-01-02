using System;
using System.Collections.Generic;
using System.Text;

namespace TwoSum
{
    class SolutionDictionary
    {
        public int[] TwoSum(int[] nums, int target)
        {

            var dictionary = new Dictionary<int, int>();

            for (var i = 0; i < nums.Length; i++)
            {
                dictionary[nums[i]] = i;
            }

            for (var i = 0; i < nums.Length - 1; i++)
            {
                var rest = target - nums[i];
                if (dictionary.ContainsKey(rest))
                    return new[] { i, dictionary[rest] };
            }

            return new int[0];
        }
    }
}
