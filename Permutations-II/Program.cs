var solution = new Solution();

//Input: nums = [1, 1, 2]
//Output:
//[[1,1,2],
// [1,2,1],
// [2,1,1]]
Console.WriteLine(solution.PermuteUnique(new int[] { 1, 1, 2 }));

// Input: nums = [1, 2, 3]
// Output: [[1,2,3],[1,3,2],[2,1,3],[2,3,1],[3,1,2],[3,2,1]]
Console.WriteLine(solution.PermuteUnique(new int[] { 1, 2, 3 }));

/// <summary>
/// Leetcode's solution
/// </summary>
class Solution
{

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        IList<IList<int>> results = new List<IList<int>>();

        // count the occurrence of each number
        Dictionary<int, int> counter = new Dictionary<int, int>();
        foreach(var num in nums)
        {
            if (!counter.ContainsKey(num))
                counter[num] = 0;
            counter[num] = counter[num] + 1;
        }

        LinkedList<int> comb = new LinkedList<int>();
        this.backtrack(comb, nums.Length, counter, results);
        return results;
    }

    protected void backtrack(
            LinkedList<int> comb,
            int N,
            Dictionary<int, int> counter,
            IList<IList<int>> results)
    {

        if (comb.Count == N)
        {
            // make a deep copy of the resulting permutation,
            // since the permutation would be backtracked later.
            results.Add(new List<int>(comb));
            return;
        }

        foreach (var item in counter)
        {
            var num = item.Key;
            int count = item.Value;
            if (count == 0)
                continue;
            // add this number into the current combination
            comb.AddLast(num);
            counter[num] = count - 1;

            // continue the exploration
            backtrack(comb, N, counter, results);

            // revert the choice for the next exploration
            comb.RemoveLast();
            counter[num] = count;
        }
    }
}

/// <summary>
/// My solution from memory
/// </summary>
public class Solution1
{
    private List<IList<int>> output = new List<IList<int>>();

    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Backtrack(0, nums.Length, nums);
        var result = new List<IList<int>>();
        foreach (var item in output)
        {
            if (!IsInResult(result, item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    private bool IsInResult(List<IList<int>> result, IList<int> sequence)
    {
        foreach (var resultItem in result)
        {
            if (resultItem.SequenceEqual(sequence))
                return true;
        }

        return false;
    }

    private void Backtrack(int first, int length, int[] nums)
    {
        if (first == length)
            output.Add(nums.ToList());

        for (var i = first; i < length; i++)
        {
            Swap(nums, first, i);
            Backtrack(first + 1, length, nums);
            Swap(nums, first, i);
        }
    }

    private void Swap(int[] nums, int index1, int index2)
    {
        var temp = nums[index1];
        nums[index1] = nums[index2];
        nums[index2] = temp;
    }
}