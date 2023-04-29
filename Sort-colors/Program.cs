// https://leetcode.com/problems/sort-colors/
var solution = new Solution();

// Input: nums = [2,0,2,1,1,0]
// Output: [0,0,1,1,2,2]
var array = new int[] { 2, 0, 2, 1, 1, 0 };
solution.SortColors(array);
Console.WriteLine(string.Join(", ", array));

array = new int[] { 2, 0, 2, 1, 1, 0 };
solution.SortColors2(array);
Console.WriteLine(string.Join(", ", array));

array = new int[] { 2, 1, 2, 1, 1, 2 };
solution.SortColors2(array);
Console.WriteLine(string.Join(", ", array));

public class Solution
{
    public void SortColors(int[] nums)
    {
        int counter0 = 0;
        int counter1 = 0;
        int counter2 = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            switch (nums[i])
            {
                case 0:
                    counter0++;
                    break;
                case 1:
                    counter1++;
                    break;
                case 2:
                    counter2++;
                    break;
            }
        }

        for (var i = 0; i < counter0; i++)
        {
            nums[i] = 0;
        }

        for (var i = counter0; i < counter0 + counter1; i++)
        {
            nums[i] = 1;
        }

        for (var i = counter0 + counter1; i < nums.Length; i++)
        {
            nums[i] = 2;
        }
    }

    /// <summary>
    /// Not mine. Dutch National Flag Algorithm
    /// https://leetcode.com/problems/sort-colors/solutions/3383797/most-optimal-solution-using-dutch-national-flag-algorithm/
    /// </summary>
    /// <param name="nums"></param>
    public void SortColors2(int[] nums)
    {
        int n = nums.Length;
        int low = 0, mid = 0, high = n - 1;
        while (mid <= high)
        {
            if (nums[mid] == 0)
            {
                swap(ref nums[low], ref nums[mid]);
                low++;
                mid++;
            }
            else if (nums[mid] == 1)
            {
                mid++;
            }
            else
            {
                swap(ref nums[mid], ref nums[high]);
                high--;
            }
        }
    }

    private void swap(ref int v1, ref int v2)
    {
        var temp = v1;
        v1 = v2;
        v2 = temp;
    }
}
