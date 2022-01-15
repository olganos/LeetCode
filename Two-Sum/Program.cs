// https://leetcode.com/problems/two-sum/
var solution = new Solution();

// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
Console.WriteLine(string.Join(", ", solution.TwoSum(new int[] { 2, 7, 11, 15 }, 9)));

// Input: nums = [3,2,4], target = 6
// Output: [1,2]
Console.WriteLine(string.Join(", ", solution.TwoSum(new int[] { 3, 2, 4 }, 6)));

// Input: nums = [3,3], target = 6
// Output: [0,1]
Console.WriteLine(string.Join(", ", solution.TwoSum(new int[] { 3, 3 }, 6)));

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var valueIndex = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            var remain = target - nums[i];
            if (valueIndex.ContainsKey(remain))
                return new int[] { i, valueIndex[remain] };

            valueIndex[nums[i]] = i;
        }

        return new int[] { -1, -1 };
    }
}