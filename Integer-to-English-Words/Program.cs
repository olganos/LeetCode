// https://leetcode.com/problems/integer-to-english-words/

var solution = new Solution();

// Input: num = 123
// Output: "One Hundred Twenty Three"
Console.WriteLine(solution.NumberToWords(123));

// Input: num = 12345
// Output: "Twelve Thousand Three Hundred Forty Five"
Console.WriteLine(solution.NumberToWords(12345));

// Input: num = 1234567
// Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"
Console.WriteLine(solution.NumberToWords(1234567));

// Input: num = 1234567891
// Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"
Console.WriteLine(solution.NumberToWords(1234567891));

// Input: num = 0
// Output: "Zero"
Console.WriteLine(solution.NumberToWords(0));

// Input: num = 113
// Output: "One Hundred Twenty Three"
Console.WriteLine(solution.NumberToWords(113));

// Input: num = 120
// Output: "One Hundred Twenty"
Console.WriteLine(solution.NumberToWords(120));

// Input: num = 110
// Output: "One Hundred Ten"
Console.WriteLine(solution.NumberToWords(110));

// Input: num = 1000
// Output: "One Thousand"
var oneThousand = solution.NumberToWords(1000);
Console.WriteLine(oneThousand);
Console.WriteLine(oneThousand == "One Thousand");

// Input: num = 1000000
// Output: "One Million"
var oneMilliion = solution.NumberToWords(1000000);
Console.WriteLine(oneMilliion);
Console.WriteLine(oneMilliion == "One Million");

public class Solution
{
    public string NumberToWords(int num)
    {
        if (num == 0)
            return firstDigits[0];

        var counter = 1;
        var result = new Stack<string>();

        do
        {
            var threeDigitsConvertion = ConvertByThreeDigits(ref num);

            if (counter == 1)
                result.Push(threeDigitsConvertion);

            // thousands
            if (counter == 2 && !string.IsNullOrWhiteSpace(threeDigitsConvertion))
                result.Push(threeDigitsConvertion + " " + THOUSAND);

            // millions
            if (counter == 3 && !string.IsNullOrWhiteSpace(threeDigitsConvertion))
                result.Push(threeDigitsConvertion + " " + MILLION);

            // billions
            if (counter == 4 && !string.IsNullOrWhiteSpace(threeDigitsConvertion))
                result.Push(threeDigitsConvertion + " " + BILLION);

            counter++;
        }
        while (num != 0);

        return string.Join(" ", result).TrimEnd();
    }

    private string ConvertByThreeDigits(ref int num)
    {
        var ones = 0;
        var threeDigitsCounter = 1;

        var result = new Stack<string>();

        do
        {
            var currentDigit = num % 10;
            num /= 10;

            if (currentDigit != 0)
            {
                if (threeDigitsCounter == 1)
                {
                    result.Push(firstDigits[currentDigit]);
                    ones = currentDigit;
                }

                if (threeDigitsCounter == 2)
                {
                    if (currentDigit == 1 && ones != 0)
                    {
                        result.Pop();
                        result.Push(twoDigits[ones]);
                    }
                    else
                        result.Push(tens[currentDigit]);
                }

                if (threeDigitsCounter == 3)
                    result.Push(firstDigits[currentDigit] + " " + HUNDRED);
            }

            threeDigitsCounter++;
        }
        while (threeDigitsCounter <= 3 && num != 0);

        return string.Join(" ", result);
    }

    private string[] firstDigits = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    private string[] twoDigits = new string[] { " ", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    private string[] tens = new string[] { " ", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    private const string HUNDRED = "Hundred";
    private const string THOUSAND = "Thousand";
    private const string MILLION = "Million";
    private const string BILLION = "Billion";
}
