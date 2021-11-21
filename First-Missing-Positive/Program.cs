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

class Solution
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