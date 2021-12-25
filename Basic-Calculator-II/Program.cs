// https://leetcode.com/problems/basic-calculator-ii/

var solution = new Solution();

// Input: s = "3+2*2"
// Output: 7
Console.WriteLine(solution.Calculate("3+2*2"));

// Input: s = " 3/2 "
// Output: 1
Console.WriteLine(solution.Calculate(" 3/2 "));

// Input: s = " 3+5 / 2 "
// Output: 5
Console.WriteLine(solution.Calculate(" 3+5 / 2 "));

// Input: s = "3+2*2+7"
// Output: 14
Console.WriteLine(solution.Calculate("3+2*2+7"));

/// <summary>
/// My solution
/// </summary>
public class Solution1
{
    public int Calculate(string s)
    {
        var left = 0;
        char? action = null;
        var rigth = 0;
        var primaryLeft = 1;
        char? primaryAction = null;

        foreach (var currentChar in s)
        {
            // Numbers
            if (currentChar >= 48 && currentChar <= 57)
            {
                rigth = rigth * 10 + (currentChar - 48);
            }
            else if (currentChar == minus || currentChar == plus)
            {
                if (primaryAction != null)
                    rigth = Calculate(primaryLeft, rigth, primaryAction);
                left = Calculate(left, rigth, action);
                action = currentChar;
                rigth = 0;
                primaryLeft = 1;
                primaryAction = null;
            }
            else if (currentChar == devision || currentChar == mult)
            {
                primaryLeft = Calculate(primaryLeft, rigth, primaryAction);
                primaryAction = currentChar;
                rigth = 0;
            }
        }

        rigth = Calculate(primaryLeft, rigth, primaryAction);
        left = Calculate(left, rigth, action);

        return left;
    }

    private int Calculate(int left, int rigth, char? action)
    {
        switch (action)
        {
            case null:
                return rigth;
            case minus:
                return left - rigth;
            case plus:
                return left + rigth;
            case mult:
                return left * rigth;
            case devision:
                if (rigth == 0)
                    return left;
                return left / rigth;
        }

        return 0;
    }

    private const char minus = '-';
    private const char plus = '+';
    private const char devision = '/';
    private const char mult = '*';
}

/// <summary>
/// Leetcode''s solution
/// </summary>
public class Solution
{
    public int Calculate(string s)
    {
        if (s == null || string.IsNullOrWhiteSpace(s)) 
            return 0;

        int len = s.Length;
        Stack<int> stack = new Stack<int>();
        int currentNumber = 0;
        char operation = '+';
        for (int i = 0; i < len; i++)
        {
            char currentChar = s[i];
            if (Char.IsDigit(currentChar))
            {
                currentNumber = (currentNumber * 10) + (currentChar - '0');
            }
            if (!Char.IsDigit(currentChar) && !Char.IsWhiteSpace(currentChar) || i == len - 1)
            {
                if (operation == '-')
                {
                    stack.Push(-currentNumber);
                }
                else if (operation == '+')
                {
                    stack.Push(currentNumber);
                }
                else if (operation == '*')
                {
                    stack.Push(stack.Pop() * currentNumber);
                }
                else if (operation == '/')
                {
                    stack.Push(stack.Pop() / currentNumber);
                }
                operation = currentChar;
                currentNumber = 0;
            }
        }
        int result = 0;
        while (stack.Count != 0)
        {
            result += stack.Pop();
        }
        return result;
    }
}