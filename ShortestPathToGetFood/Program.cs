// https://leetcode.com/problems/shortest-path-to-get-food/submissions/
var solution = new Solution();

// Input: grid = [["X", "X", "X", "X", "X", "X"],["X","*","O","O","O","X"],["X","O","O","#","O","X"],["X","X","X","X","X","X"]]
// Output: 3
Console.WriteLine(solution.GetFood(
    new char [][]{
        new char [] { 'X', 'X', 'X', 'X', 'X', 'X' },
        new char [] { 'X', '*', 'O', 'O', 'O', 'X' },
        new char [] { 'X', 'O', 'O', '#', 'O', 'X' },
        new char [] { 'X', 'X', 'X', 'X', 'X', 'X' },
    }));

// Input: grid = [["X", "X", "X", "X", "X"],["X","*","X","O","X"],["X","O","X","#","X"],["X","X","X","X","X"]]
// Output: -1
Console.WriteLine(solution.GetFood(
    new char[][]{
        new char [] { 'X', 'X', 'X', 'X', 'X' },
        new char [] { 'X', '*', 'X', 'O', 'X' },
        new char [] { 'X', 'O', 'X', '#', 'X' },
        new char [] { 'X', 'X', 'X', 'X', 'X' },
    }));

// Input: grid = [["X", "X", "X", "X", "X", "X", "X", "X"],["X","*","O","X","O","#","O","X"],["X","O","O","X","O","O","X","X"],
// ["X","O","O","O","O","#","O","X"],["X","X","X","X","X","X","X","X"]]
// Output: 6
Console.WriteLine(solution.GetFood(
    new char[][]{
        new char [] { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
        new char [] { 'X', '*', 'O', 'X', 'O', '#', 'O', 'X' },
        new char [] { 'X', 'O', 'O', 'X', 'O', 'O', 'X', 'X' },
        new char [] { 'X', 'O', 'O', 'O', 'O', '#', 'O', 'X' },
        new char [] { 'X', 'X', 'X', 'X', 'X', 'X', 'X', 'X' },
    }));

// Input: grid = [["O","*"],["#","O"]]
// Output: 2
Console.WriteLine(solution.GetFood(
    new char[][]{
        new char [] { 'O', '*' },
        new char [] { '#', 'O' },
    }));

// Input: grid = [["X","*"],["#","X"]]
// Output: -1
Console.WriteLine(solution.GetFood(
    new char[][]{
        new char [] { 'X', '*' },
        new char [] { '#', 'X' },
    }));

public class Solution
{

    private const char Me = '*';
    private const char Free = '0';
    private const char Obstacle = 'X';
    private const char Food = '#';

    public int GetFood(char[][] grid)
    {

        for (var i = 0; i < grid.Length; i++)
        {
            for (var j = 0; j < grid[0].Length; j++)
            {
                if (grid[i][j] == Me)
                {
                    return Bfs(grid, i, j);
                }
            }
        }

        return -1;
    }

    private int Bfs(char[][] grid, int startRow, int startCol)
    {
        var queue = new Queue<State>();
        var seen = new bool[grid.Length][];
        for(var i = 0; i < grid.Length; i++)
        {
            seen[i] = new bool[grid[0].Length];
        }

        queue.Enqueue(new State(startRow, startCol, 0));

        while (queue.Any())
        {
            var current = queue.Dequeue();
            if (grid[current.row][current.col] == Food)
                return current.steps;

            var nextSteps = new[] {
                current.row, current.col + 1, current.row - 1, current.col,
                current.row, current.col - 1, current.row + 1, current.col
            };

            for (var i = 0; i < nextSteps.Length; i += 2)
            {
                var nextRow = nextSteps[i];
                var nextCol = nextSteps[i + 1];

                if (nextRow < 0 || nextRow > grid.Length - 1
                    || nextCol < 0 || nextCol > grid[0].Length - 1
                   || grid[nextRow][nextCol] == Obstacle)
                {
                    continue;
                }

                var newState = new State(nextRow, nextCol, current.steps + 1);
                if (!seen[nextRow][nextCol])
                {
                    seen[nextRow][nextCol] = true;
                    queue.Enqueue(newState);
                }
            }
        }

        return -1;
    }
}

public class State
{
    public int steps { get; set; }
    public int row { get; set; }
    public int col { get; set; }

    public State(int row, int col, int steps)
    {
        this.row = row;
        this.col = col;
        this.steps = steps;
    }
}