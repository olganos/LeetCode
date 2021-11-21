// https://leetcode.com/problems/largest-time-for-given-digits/
// Made by myself, but it was difficult to find cobinations

// Input: arr = [1, 2, 3, 4]
// Output: "23:41"
var solution = new Solution();
Console.WriteLine(solution.LargestTimeFromDigits(new int [] { 1, 2, 3, 4 }));

// Input: arr = [0,0,0,0]
// Output: "00:00"
solution = new Solution();
Console.WriteLine(solution.LargestTimeFromDigits(new int[] { 0, 0, 0, 0 }));

// Input: arr = [0,0,1,0]
// Output: "10:00"
solution = new Solution();
Console.WriteLine(solution.LargestTimeFromDigits(new int[] { 0, 0, 1, 0 }));

// Input: arr = [5,5,5,5]
// Output: ""
solution = new Solution();
Console.WriteLine(solution.LargestTimeFromDigits(new int[] { 5, 5, 5, 5 }));

public class Solution
{
    private int[] maxTime = new int[2] { -1, -1 };

    public string LargestTimeFromDigits(int[] arr)
    {
        shiftArray(new int[0], arr);

        if (maxTime[0] == -1)
            return string.Empty;

        return $"{maxTime[0]:D2}:{maxTime[1]:D2}";
    }

    private void shiftArray(int[] prevArray, int[] array)
    {
        var arrayLength = array.Length;
        if (arrayLength == 1)
            return;

        var shiftTimes = arrayLength;
        while (shiftTimes != 0)
        {
            var first = array[0];
            for (var i = 0; i < arrayLength; i++)
            {
                if (i == arrayLength - 1)
                {
                    array[i] = first;
                    break;
                }

                array[i] = array[i + 1];
            }

            shiftTimes--;


            var newTime = new List<int>();
            newTime.AddRange(prevArray);
            newTime.AddRange(array);
            CheckMaxTime(newTime.ToArray());

            var newPrevArray = new List<int>(prevArray);
            newPrevArray.Add(array.First());
            var newArray = array.Skip(1).ToArray();
            shiftArray(newPrevArray.ToArray(), newArray);
        }
    }

    private void CheckMaxTime(int[] time)
    {
        if (time.Length != 4)
            return;

        var hours = time[0] * 10 + time[1];
        var minutes = time[2] * 10 + time[3];

        if (hours < 0 || hours > 23)
            return;

        if (minutes < 0 || minutes > 59)
            return;

        if (hours > maxTime[0])
        {
            maxTime[0] = hours;
            maxTime[1] = minutes;
            return;
        }

        if (hours == maxTime[0] && minutes > maxTime[1])
        {
            maxTime[0] = hours;
            maxTime[1] = minutes;
            return;
        }
    }
}
