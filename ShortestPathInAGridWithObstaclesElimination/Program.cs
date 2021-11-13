// https://leetcode.com/problems/shortest-path-in-a-grid-with-obstacles-elimination/

// Not my solution, just convert java example to C# and debug in order to understand the algorithm

var solution = new Solution();

// Input: grid = [[0,0,0],[1,1,0],[0,0,0],[0,1,1],[0,0,0]], k = 1
// Output: 6
Console.WriteLine(solution.shortestPath(new int[][]
{
    new int[] {0, 0, 0},
    new int[] {1, 1, 0},
    new int[] {0, 0, 0},
    new int[] {0, 1, 1},
    new int[] {0, 0, 0},
}, 1));

// Input: grid = [[0,1,1],[1,1,1],[1,0,0]], k = 1
// Output: -1
Console.WriteLine(solution.shortestPath(new int[][]
{
    new int[] {0, 1, 1},
    new int[] {1, 1, 1},
    new int[] {1, 0, 0},
}, 1));

class StepState
{
    /**
     * data object to keep the state info for each step:
     * <steps, row, col, remaining_eliminations>
     */
    public int steps, row, col, k;

    public StepState(int steps, int row, int col, int k)
    {
        this.steps = steps;
        this.row = row;
        this.col = col;
        this.k = k;
    }

    public override int GetHashCode()
    {
        // needed when we put objects into any container class
        return (row + 1) * (col + 1) * k;
    }

    public override bool Equals(Object other)
    {
        /**
         * only (row, col, k) matters as the state info
         */
        if (other is not StepState)
        {
            return false;
        }
        StepState newState = (StepState)other;
        return (row == newState.row) && (col == newState.col) && (k == newState.k);
    }

    public override String ToString()
    {
        return $"row - {row}; col - {col}; k - {k}; steps - {steps}";
    }
}

class Solution
{
    public int shortestPath(int[][] grid, int k)
    {
        int rows = grid.Length, cols = grid[0].Length;
        int[] target = { rows - 1, cols - 1 };

        // if we have sufficient quotas to eliminate the obstacles in the worst case,
        // then the shortest distance is the Manhattan distance.
        if (k >= rows + cols - 2)
        {
            return rows + cols - 2;
        }

        Queue<StepState> queue = new Queue<StepState>();
        HashSet<StepState> seen = new HashSet<StepState>();

        // (steps, row, col, remaining quota to eliminate obstacles)
        StepState start = new StepState(0, 0, 0, k);
        queue.Enqueue(start);
        seen.Add(start);

        while (queue.Any())
        {
            StepState curr = queue.Dequeue();

            // we reach the target here
            if (target[0] == curr.row && target[1] == curr.col)
            {
                return curr.steps;
            }

            int[] nextSteps = {curr.row, curr.col + 1, curr.row + 1, curr.col,
                    curr.row, curr.col - 1, curr.row - 1, curr.col};

            // explore the four directions in the next step
            for (int i = 0; i < nextSteps.Length; i += 2)
            {
                int nextRow = nextSteps[i];
                int nextCol = nextSteps[i + 1];

                // out of the boundary of grid
                if (0 > nextRow || nextRow == rows || 0 > nextCol || nextCol == cols)
                {
                    continue;
                }

                int nextElimination = curr.k - grid[nextRow][nextCol];
                StepState newState = new StepState(curr.steps + 1, nextRow, nextCol, nextElimination);

                // add the next move in the queue if it qualifies.
                if (nextElimination >= 0 && !seen.Contains(newState))
                {
                    seen.Add(newState);
                    queue.Enqueue(newState);
                }
            }
        }

        // did not reach the target
        return -1;
    }
}