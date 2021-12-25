// https://leetcode.com/problems/combinations

var solution = new Solution();

// Input: n = 4, k = 2
//    Output:
//    [
//      [2,4],
//      [3,4],
//      [2,3],
//      [1,2],
//      [1,3],
//      [1,4],
//    ]
Console.WriteLine(solution.Combine(4, 2));

/// <summary>
/// Leedcode's solution
/// </summary>
class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        // init first combination
        var nums = new int[k + 1];
        for (int i = 0; i < k; ++i)
            nums[i] = i + 1;
        nums[k] = n + 1;

        var output = new List<IList<int>>();
        int j = 0;
        while (j < k)
        {
            // add current combination
            output.Add(new List<int>(nums.Take(k)));
            // increase first nums[j] by one
            // if nums[j] + 1 != nums[j + 1]
            j = 0;
            while ((j < k) && (nums[j + 1] == nums[j] + 1))
            {
                var _1 = nums[j + 1];
                var _2 = nums[j] + 1;
                //var newValue =;
                nums[j] = j++ + 1;
                var newValue = nums[j];
            }
            nums[j] = nums[j] + 1;
        }
        return output;
    }
}

/// <summary>
/// My solution from memory
/// </summary>
public class Solution1
{
    private int k;
    private int n;
    private IList<IList<int>> output = new List<IList<int>>();

    public IList<IList<int>> Combine(int n, int k)
    {
        this.k = k;
        this.n = n;

        Backtrack(1, new Stack<int>());
        return output;
    }

    private void Backtrack(int first, Stack<int> current)
    {
        if (current.Count == k)
            output.Add(current.ToList());

        for (var i = first; i <= n; i++)
        {
            current.Push(i);
            Backtrack(i + 1, current);
            current.Pop();
        }
    }
}

/// <summary>
/// Leetcode's solution
/// </summary>
class Solution2
{
    private IList<IList<int>> output = new List<IList<int>>();
    int n;
    int k;

    private void Backtrack(int first, List<int> curr)
    {
        // if the combination is done
        if (curr.Count == k)
            output.Add(curr.ToList());
        for (int i = first; i < n + 1; ++i)
        {
            // add i into the current combination
            curr.Add(i);
            // use next integers to complete the combination
            Backtrack(i + 1, curr);
            // backtrack
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public IList<IList<int>> Combine(int n, int k)
    {

        this.n = n;
        this.k = k;

        Backtrack(1, new List<int>());
        return output;
    }
}

