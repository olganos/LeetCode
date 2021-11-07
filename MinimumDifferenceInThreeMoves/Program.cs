// https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves/submissions/

var solution = new Solution();

// Output - 0
Console.WriteLine(solution.MinDifference(new int[] { 5, 3, 2, 4 }));

// Output - 1
Console.WriteLine(solution.MinDifference(new int[] { 1, 5, 0, 10, 14 }));

// Output - 2
Console.WriteLine(solution.MinDifference(new int[] { 6, 6, 0, 1, 1, 4, 6 }));

// Output - 1
Console.WriteLine(solution.MinDifference(new int[] { 1, 5, 6, 14, 15 }));


public class Solution
{
    public int MinDifference(int[] nums)
    {
        var length = nums.Length;
        // The simplest case.
        // If less than 4 items, it is possible to make the difference 0
        if (length <= 4)
            return 0;

        Array.Sort(nums);

        // Check the diff berween fourth from the end and first numbers
        var minDifference = nums[length - 4] - nums[0];

        // Check the diff berween the last and fourth from the begining numbers
        var diff = nums[length - 1] - nums[3];
        minDifference = diff < minDifference ? diff : minDifference;

        // Check the diff from both ends of nums

        // 3d from the end and second from the beginig
        diff = nums[length - 3] - nums[1];
        minDifference = diff < minDifference ? diff : minDifference;

        // 3d from the begining and second from the end
        diff = nums[length - 2] - nums[2];
        minDifference = diff < minDifference ? diff : minDifference;

        return minDifference;
    }
}
