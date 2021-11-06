// See https://aka.ms/new-console-template for more information
// https://leetcode.com/problems/logger-rate-limiter/

var logger = new Logger();

// result true
Console.WriteLine($"true - {logger.ShouldPrintMessage(1, "foo")}");

// result true
Console.WriteLine($"true - {logger.ShouldPrintMessage(2, "bar")}");

// result false
Console.WriteLine($"false - {logger.ShouldPrintMessage(3, "foo")}");

// result false
Console.WriteLine($"false - {logger.ShouldPrintMessage(8, "bar")}");

// result false
Console.WriteLine($"false - {logger.ShouldPrintMessage(10, "foo")}");

// result true
Console.WriteLine($"true - {logger.ShouldPrintMessage(11, "foo")}");

public class Logger
{

    private Dictionary<string, int> _hashTable = new Dictionary<string, int>();

    public Logger()
    {

    }

    public bool ShouldPrintMessage(int timestamp, string message)
    {
        if (!_hashTable.ContainsKey(message))
        {
            _hashTable[message] = timestamp;
            return true;
        }

        if ((_hashTable[message] + 10) <= timestamp)
        {
            _hashTable[message] = timestamp;
            return true;
        }

        return false;
    }
}

/**
 * Your Logger object will be instantiated and called as such:
 * Logger obj = new Logger();
 * bool param_1 = obj.ShouldPrintMessage(timestamp,message);
 */
