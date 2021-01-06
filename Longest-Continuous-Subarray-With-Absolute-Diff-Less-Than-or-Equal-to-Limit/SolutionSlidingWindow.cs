using System;

namespace Longest_Continuous_Subarray_With_Absolute_Diff_Less_Than_or_Equal_to_Limit
{
    /// <summary>
    /// Faster solution
    /// </summary>
    public class SolutionSlidingWindow
    {
        public int LongestSubarray(int[] nums, int limit)
        {

            var maxLength = 1;
            var min = nums[0];
            var max = nums[0];
            var leftEdge = 0;

            var minChanged = false;
            var maxChanged = false;

            for (var i = 1; leftEdge + maxLength < nums.Length; i++)
            {
                minChanged = false;
                maxChanged = false;

                if (nums[i] > max)
                {
                    maxChanged = true;
                    max = nums[i];
                }
                else if (nums[i] < min)
                {
                    minChanged = true;
                    min = nums[i];
                }

                if (Math.Abs(max - min) <= limit)
                {
                    maxLength = Math.Max(maxLength, i - leftEdge + 1);
                    continue;
                }

                leftEdge++;
                // Figure out new min and max
                if (!minChanged)
                {
                    // looking for min
                    min = nums[leftEdge];
                    for (var j = leftEdge + 1; j <= i; j++)
                    {
                        min = Math.Min(nums[j], min);
                    }
                }

                if (!maxChanged)
                {
                    // looking for max
                    max = nums[leftEdge];
                    for (var j = leftEdge + 1; j <= i; j++)
                    {
                        max = Math.Max(nums[j], max);
                    }
                }
            }

            return maxLength;
        }
    }
}
