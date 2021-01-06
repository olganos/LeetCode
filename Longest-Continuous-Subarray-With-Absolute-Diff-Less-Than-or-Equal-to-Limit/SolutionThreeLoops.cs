using System;

namespace Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit
{
    class SolutionThreeLoops
    {
        /// <summary>
        /// Time Limit Exceeded in Leetcode
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums, int limit)
        {
            var longestArrayLength = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                var currentSubarrayLength = nums.Length;
                for (var j = i; j < currentSubarrayLength; j++)
                {
                    for (var k = j; k < currentSubarrayLength; k++)
                    {
                        if (Math.Abs(nums[j] - nums[k]) > limit)
                        {
                            currentSubarrayLength = k;
                            break;
                        }
                    }
                }
                longestArrayLength = Math.Max(currentSubarrayLength - i, longestArrayLength);
            }

            return longestArrayLength;
        }
    }
}
