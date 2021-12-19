// https://leetcode.com/problems/permutations/

var solution = new Solution();

// Input: nums = [1, 2, 3]
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Console.WriteLine(solution.Permute(new int[] { 1, 2, 3 }));

/// <summary>
/// My solution from memory
/// </summary>
public class Solution {
    public IList<IList<int>> Permute(int[] nums) {
        var output = new List<IList<int>>();
        backtrack(0, nums, nums.Length, output);
        return output;
    }
    
    private void backtrack(int first, int[] nums, int length, IList<IList<int>> output) 
    {
        if(first == length) 
            output.Add(nums.ToList());
        
        for(var i = first; i < length; i++)
        {
            Swap(nums, first, i);
            backtrack(first + 1, nums, length, output);
            Swap(nums, first, i);
        }
    }
    
    private void Swap(int[] nums, int index1, int index2){
        var temp = nums[index1];
        nums[index1] = nums[index2];
        nums[index2] = temp;            
    }
}

/// <summary>
/// Leetcode's solution
/// </summary>
class Solution2
{
    private void Backtrack(int n,
                         int[] nums,
                         IList<IList<int>> output,
                         int first)
    {
        // if all integers are used up
        if (first == n)
            output.Add(nums.ToList());
        for (int i = first; i < n; i++)
        {
            // place i-th integer first 
            // in the current permutation
            Swap(nums, first, i);
            // use next integers to complete the permutations
            Backtrack(n, nums, output, first + 1);
            // backtrack
            Swap(nums, first, i);
        }
    }

    public IList<IList<int>> Permute(int[] nums)
    {
        // init output list
        IList<IList<int>> output = new List<IList<int>>();

        Backtrack(nums.Length, nums, output, 0);
        return output;
    }

    private static void Swap(int[] array, int index1, int index2)
    {
        var temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }
}
