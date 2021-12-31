// https://leetcode.com/problems/sign-of-the-product-of-an-array/
var solution = new Solution();
// Input: [-1,-2,-3,-4,3,2,1]
// Output: 1
Console.WriteLine(solution.ArraySign(new[] { -1, -2, -3, -4, 3, 2, 1 }));

// Input: [1,5,0,2,-3]
// Output: 0
Console.WriteLine(solution.ArraySign(new[] { 1, 5, 0, 2, -3 }));

// Input: [-1,1,-1,1,-1]
// Output: -1
Console.WriteLine(solution.ArraySign(new[] { -1, 1, -1, 1, -1 }));

// Input: [41,65,14,80,20,10,55,58,24,56,28,86,96,10,3,84,4,41,13,32,42,43,83,78,82,70,15,-41]
// Output: -1
Console.WriteLine(solution.ArraySign(new[] { 41, 65, 14, 80, 20, 10, 55, 58, 24, 56, 28, 86, 96, 10, 3, 84, 4, 41, 13, 32, 42, 43, 83, 78, 82, 70, 15, -41 }));

public class Solution
{
    public int ArraySign(int[] nums)
    {
        var product = 1;
        foreach (var num in nums)
        {
            if (num == 0)
                return 0;

            product *= num;
            if (product > 0)
                product = 1;
            else
                product = -1;
        }

        return product;
    }
}
