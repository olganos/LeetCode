using System;
using System.Linq;

namespace RichestCustomerWealth
{
    /// <summary>
    /// https://leetcode.com/problems/richest-customer-wealth/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Input: accounts = [[1,2,3],[3,2,1]]
            // Output: 6
            var solution = new Solution();
            Console.WriteLine(solution.MaximumWealth(new[]
            {
                new []{ 1, 2, 3 },
                new []{ 3, 2, 1 }
            }));
            Console.WriteLine();

            // Input: accounts = [[1,5],[7,3],[3,5]]
            // Output: 10
            Console.WriteLine(solution.MaximumWealth(new[]
            {
                new []{ 1,5 },
                new []{ 7,3 },
                new []{ 3, 5 }
            }));
            Console.WriteLine();

            // Input: accounts = [[2,8,7],[7,1,3],[1,9,5]]
            // Output: 17
            Console.WriteLine(solution.MaximumWealth(new[]
            {
                new []{ 2,8,7 },
                new []{ 7, 1, 3 },
                new []{ 1, 9, 5 }
            }));
            Console.WriteLine();
        }
    }

    public class Solution
    {
        public int MaximumWealth(int[][] accounts)
        {
            return accounts.Max(x => x.Sum());
        }
    }
}
