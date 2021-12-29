// https://leetcode.com/problems/first-missing-positive/
var solution = new Solution();
// Output: 2
Console.WriteLine(solution.FirstMissingPositive(new[] { -9000, -86543, 10000, 546, 987432, 1, 1, 3, 3, -3, -4, -1, -1 }));

// Input: nums = [1, 2, 0]
// Output: 3
solution = new Solution();
Console.WriteLine(solution.FirstMissingPositive(new[] { 1, 2, 0 }));

// Input: nums = [3, 4, -1, 1]
// Output: 2
solution = new Solution();
Console.WriteLine(solution.FirstMissingPositive(new[] { 3, 4, -1, 1 }));

// Input: nums = [7, 8, 9, 11, 12]
// Output: 1
solution = new Solution();
Console.WriteLine(solution.FirstMissingPositive(new[] { 7, 8, 9, 11, 12 }));

/// <summary>
/// space O(1) approach
/// </summary>
public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        // check if 1 exists
        var oneExists = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
            {
                oneExists++;
                break;
            }
        }

        if (oneExists == 0)
            return 1;

        // replace 0, negative and numbers equal or more than length by 1
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] <= 0 || nums[i] > nums.Length)
                nums[i] = 1;
        }

        // convert indeces of existing numbers to negative
        for (var i = 0; i < nums.Length; i++)
        {
            var checkingIndex = Math.Abs(nums[i]);
            if (checkingIndex == nums.Length)
                nums[0] = -Math.Abs(nums[0]);
            else
                nums[checkingIndex] = -Math.Abs(nums[checkingIndex]);
        }

        // check missing number
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] > 0)
            {
                return i;
            }
        }

        if (nums[0] > 0)
        {
            return nums.Length;
        }

        return nums.Length + 1;
    }
}

/// <summary>
/// Space O(n) approach
/// </summary>
class Solution2
{
    private HashSet<int> exists = new HashSet<int>();

    public int FirstMissingPositive(int[] A)
    {
        var minPositive = 1;
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > 0 && A[i] == minPositive)
            {
                do
                {
                    minPositive++;
                }
                while (exists.Contains(minPositive));
            }

            exists.Add(A[i]);
        }

        return minPositive;
    }
}