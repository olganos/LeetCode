using System;
using System.Collections.Generic;
using System.Text;

namespace TwoSum
{
    /// <summary>
    /// Only one loop.
    /// Not mine, but the best.
    /// </summary>
    class SolutionDictionaryOnePass
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dictionary = new Dictionary<int, int>(nums.Length);
            for (var i = 0; i < nums.Length; i++)
            {
                var rest = target - nums[i];
                if (dictionary.ContainsKey(rest))
                    return new[] { i, dictionary[rest] };

                dictionary[nums[i]] = i;
            }

            return new int[0];
        }
    }
}
