using System;
using System.Linq;

namespace Maximum_Points_You_Can_Obtain_from_Cards
{
    class Program
    {
        /// <summary>
        /// https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/submissions/
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var solution = new Solution();
            // Input: cardPoints = [1, 2, 3, 4, 5, 6, 1], k = 3
            // Output: 12
            Console.WriteLine(solution.MaxScore(new[] { 1, 2, 3, 4, 5, 6, 1 }, 3));

            // Input: cardPoints = [2, 2, 2], k = 2
            // Output: 4
            Console.WriteLine(solution.MaxScore(new[] { 2, 2, 2 }, 2));

            // Input: cardPoints = [9,7,7,9,7,7,9], k = 7
            // Output: 55
            Console.WriteLine(solution.MaxScore(new[] { 9, 7, 7, 9, 7, 7, 9 }, 7));

            // Input: cardPoints = [1,1000,1], k = 1
            // Output: 1
            Console.WriteLine(solution.MaxScore(new[] { 1, 1000, 1 }, 1));

            // Input: cardPoints = [1,79,80,1,1,1,200,1], k = 3
            // Output: 202
            Console.WriteLine(solution.MaxScore(new[] { 1, 79, 80, 1, 1, 1, 200, 1 }, 3));
        }
    }

    public class Solution
    {
        public int MaxScore(int[] cardPoints, int k)
        {

            if (k > cardPoints.Length)
                throw new ArgumentException();

            var generalSum = cardPoints.Sum();
            var shiftingWindowLength = cardPoints.Length - k;

            // sum for k-items of initial array
            var shiftingWindowSum = 0;
            for (var i = 0; i < shiftingWindowLength; i++)
            {
                shiftingWindowSum += cardPoints[i];
            }

            // sum for begining and end
            var max = generalSum - shiftingWindowSum;
            for (var i = shiftingWindowLength; i < cardPoints.Length; i++)
            {
                shiftingWindowSum = shiftingWindowSum - cardPoints[i - shiftingWindowLength] + cardPoints[i];

                if (max < generalSum - shiftingWindowSum)
                    max = generalSum - shiftingWindowSum;
            }

            return max;
        }
    }
}
