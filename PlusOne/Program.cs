// See https://aka.ms/new-console-template for more information
var solution = new Solution();

// Output: [9,9,0]
Console.WriteLine($"expects [9,9,0]; result {string.Join(", ", solution.PlusOne(new int[] { 9, 8, 9 }))}");

// Output: [1,2,4]
Console.WriteLine($"expects [1,2,4]; result {string.Join(", ", solution.PlusOne(new int[] { 1, 2, 3 }))}");

// Output: [4,3,2,2]
Console.WriteLine($"expects [4,3,2,2]; result {string.Join(", ", solution.PlusOne(new int[] { 4, 3, 2, 1 }))}");

// Output: [1]
Console.WriteLine($"expects [1]; result {string.Join(", ", solution.PlusOne(new int[] { 0 }))}");

// Output: [ 1, 0 ]
Console.WriteLine($"expects [ 1, 0 ]; result {string.Join(", ", solution.PlusOne(new int[] { 9 }))}");

// Output: [1,2,4]
Console.WriteLine($"expects [1,2,4]; result {string.Join(", ", solution.PlusOne(new int[] { 1, 2, 3 }))}");

// Output: [9,8,7,6,5,4,3,2,1,1]
Console.WriteLine($"expects [9,8,7,6,5,4,3,2,1,1]; result {string.Join(", ", solution.PlusOne(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }))}");

// Output: [7,2,8,5,0,9,1,2,9,5,3,6,6,7,3,2,8,4,3,7,9,5,7,7,4,7,4,9,4,7,0,1,1,1,7,4,0,0,7]
Console.WriteLine($"expects [7,2,8,5,0,9,1,2,9,5,3,6,6,7,3,2,8,4,3,7,9,5,7,7,4,7,4,9,4,7,0,1,1,1,7,4,0,0,7]; result {string.Join(", ", solution.PlusOne(new int[] { 7, 2, 8, 5, 0, 9, 1, 2, 9, 5, 3, 6, 6, 7, 3, 2, 8, 4, 3, 7, 9, 5, 7, 7, 4, 7, 4, 9, 4, 7, 0, 1, 1, 1, 7, 4, 0, 0, 6 }))}");

public class Solution
{
    public int[] PlusOne(int[] digits)
    {
        var lastIndex = digits.Length - 1;
        var lastDigit = digits[lastIndex];

        // The simplest case
        if (lastDigit != 9)
        {
            digits[lastIndex] = lastDigit + 1;
            return digits;
        }

        // Other cases (9 + 1 = 10)
        var result = new Stack<int>();
        result.Push(0);
        var inMemo = 1;

        // Start with last minus one index, because we've already prosessed the last one
        for (int i = lastIndex - 1; i >= 0; i--)
        {
            var newItem = digits[i];
            if(inMemo == 1)
            {
                newItem = newItem + inMemo;
                if (newItem == 10)
                {
                    newItem = 0;
                    inMemo = 1;
                }
                else
                {
                    inMemo = 0;
                }
            }

            result.Push(newItem); 
        }

        // Check that new array should be extenden on 1
        if(inMemo == 1)
        {
            result.Push(1);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Works only with long. 
    /// </summary>
    /// <param name="digits"></param>
    /// <returns></returns>
    public int[] PlusOneLong(int[] digits)
    {
        long largeInteger = 0;
        for (var i = 0; i < digits.Length; i++)
        {
            largeInteger *= 10;
            largeInteger += digits[i];
        }

        largeInteger++;

        var newList = new List<int>();
        while (largeInteger != 0)
        {
            newList.Add((int) (largeInteger % 10));
            largeInteger /= 10;
        }

        newList.Reverse();
        return newList.ToArray();
    }
}
