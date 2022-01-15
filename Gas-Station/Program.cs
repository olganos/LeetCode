var solution = new Solution();

// Input: gas = [1, 2, 3, 4, 5], cost = [3, 4, 5, 1, 2]
// Output: 3
Console.WriteLine(solution.CanCompleteCircuit(
    new int[] { 1, 2, 3, 4, 5 },
    new int[] { 3, 4, 5, 1, 2 })
);

// Input: gas = [2, 3, 4], cost = [3, 4, 3]
// Output: -1
Console.WriteLine(solution.CanCompleteCircuit(
    new int[] { 2, 3, 4 },
    new int[] { 3, 4, 3 })
);

/// <summary>
/// Solution from leetcode
/// </summary>
class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int n = gas.Length;

        int total_tank = 0;
        int curr_tank = 0;
        int starting_station = 0;
        for (int i = 0; i < n; ++i)
        {
            total_tank += gas[i] - cost[i];
            curr_tank += gas[i] - cost[i];
            // If one couldn't get here,
            if (curr_tank < 0)
            {
                // Pick up the next station as the starting one.
                starting_station = i + 1;
                // Start with an empty tank.
                curr_tank = 0;
            }
        }
        return total_tank >= 0 ? starting_station : -1;
    }
}

/// <summary>
/// My first solution, because I found the task description incorrect
/// </summary>
public class Solution2
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        for (var i = 0; i < gas.Length; i++)
        {
            var rest = 0;
            var currentIndex = i;
            var counter = 1;

            while (true)
            {
                if (counter == 1)
                {
                    rest = gas[currentIndex];
                }
                else
                {
                    currentIndex = currentIndex < gas.Length ? currentIndex : 0;
                    var prevIndex = currentIndex == 0 ? gas.Length - 1 : currentIndex - 1;
                    rest = rest - cost[prevIndex] + gas[currentIndex];
                }

                if (rest <= 0 || (counter != 1 && currentIndex == i))
                    break;

                currentIndex++;
                counter++;
            }

            if (rest > 0)
                return i;
        }

        return -1;
    }
}