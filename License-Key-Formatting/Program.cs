// mock interview 

//You are given a license key represented as a string s that consists of only alphanumeric characters and dashes. The string is separated into n + 1 groups by n dashes. You are also given an integer k.

//We want to reformat the string s such that each group contains exactly k characters, except for the first group, which could be shorter than k but still must contain at least one character. Furthermore, there must be a dash inserted between two groups, and you should convert all lowercase letters to uppercase.

//Return the reformatted license key.

var solution = new Solution();

// Input: s = "5F3Z-2e-9-w", k = 4
//Output: "5F3Z-2E9W"
Console.WriteLine(solution.LicenseKeyFormatting("5F3Z-2e-9-w", 4));

// Input: s = "2-5g-3-J", k = 2
// Output: "2-5G-3J"
Console.WriteLine(solution.LicenseKeyFormatting("2-5g-3-J", 2));

public class Solution
{
    public string LicenseKeyFormatting(string s, int k)
    {
        // 1. Calculate the length of the resulting array 
        var dashCount = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == '-')
                dashCount++;
        }

        var lengthWithoutDashs = s.Length - dashCount;
        var newLicenseKeyLength = 0;
        if ((lengthWithoutDashs % k) == 0)
        {
            newLicenseKeyLength = lengthWithoutDashs + (lengthWithoutDashs / k) - 1;
        }
        else
        {
            newLicenseKeyLength = lengthWithoutDashs + (lengthWithoutDashs / k);
        }

        Console.WriteLine(newLicenseKeyLength);

        // 2. Convert initial license key to the result
        var newLicenseKey = new char[newLicenseKeyLength];
        var groupLengthCounter = 1;
        var newLicenseKeyIndex = newLicenseKeyLength - 1;
        for (var i = s.Length - 1; i >= 0 && i >= newLicenseKeyIndex; i--)
        {
            if (s[i] == '-')
                continue;

            if (groupLengthCounter != k)
            {
                groupLengthCounter++;
                newLicenseKey[newLicenseKeyIndex] = Char.ToUpper(s[i]);
            }
            else
            {
                groupLengthCounter = 1;
                newLicenseKey[newLicenseKeyIndex] = Char.ToUpper(s[i]);
                newLicenseKeyIndex--;
                if(newLicenseKeyIndex >= 0)
                    newLicenseKey[newLicenseKeyIndex] = '-';
            }

            newLicenseKeyIndex--;
        }


        return new String(newLicenseKey);
    }
}