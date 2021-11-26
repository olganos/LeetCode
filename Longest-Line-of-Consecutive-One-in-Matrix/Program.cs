// https://leetcode.com/problems/longest-line-of-consecutive-one-in-matrix/

// Input: mat = [[0, 1, 1, 0],[0,1,1,0],[0,0,0,1]]
// Output: 3
var solution = new Solution();
Console.WriteLine(solution.LongestLine(
    new int[][]
    {
        new int[] {0, 1, 1, 0 },
        new int[] {0,1,1,0 },
        new int[] {0,0,0,1 },
    }));

// Input: mat = [[1,1,1,1],[0,1,1,0],[0,0,0,1]]
// Output: 4
solution = new Solution();
Console.WriteLine(solution.LongestLine(
    new int[][]
    {
        new int[] {1,1,1,1 },
        new int[] {0,1,1,0 },
        new int[] {0,0,0,1 },
    }));

// Input: mat = [[1,1,0,0,1,0,0,1,1,0],[1,0,0,1,0,1,1,1,1,1],[1,1,1,0,0,1,1,1,1,0],[0,1,1,1,0,1,1,1,1,1],
// [0,0,1,1,1,1,1,1,1,0],[1,1,1,1,1,1,0,1,1,1],[0,1,1,1,1,1,1,0,0,1],[1,1,1,1,1,0,0,1,1,1],[0,1,0,1,1,0,1,1,1,1],[1,1,1,0,1,0,1,1,1,1]]
// Output: 9
solution = new Solution();
Console.WriteLine(solution.LongestLine(
    new int[][]
    {
        new int[] {1,1,0,0,1,0,0,1,1,0},
        new int[] {1,0,0,1,0,1,1,1,1,1 },
        new int[] {1,1,1,0,0,1,1,1,1,0 },
        new int[] {0,1,1,1,0,1,1,1,1,1},
        new int[] {0,0,1,1,1,1,1,1,1,0 },
        new int[] {1,1,1,1,1,1,0,1,1,1 },
        new int[] {0,1,1,1,1,1,1,0,0,1},
        new int[] {1,1,1,1,1,0,0,1,1,1 },
        new int[] {0,1,0,1,1,0,1,1,1,1 },
        new int[] { 1, 1, 1, 0, 1, 0, 1, 1, 1, 1 }
    }));

public class Solution
{
    private int max;

    public int LongestLine(int[][] mat)
    {
        var colLength = mat.Length;
        var rowLength = mat[0].Length;
        for (var i = 0; i < colLength; i++)
        {
            for (var j = 0; j < rowLength; j++)
            {
                if (mat[i][j] == 1)
                {
                    GoOnRow(mat, i, j);
                    GoOnCol(mat, i, j);
                    GoOnDiagonal(mat, i, j);
                    GoOnAntiDiagonal(mat, i, j);
                }
            }
        }

        return max;
    }

    private void GoOnRow(int[][] mat, int colIndex, int rowIndex)
    {
        var rowLength = mat[colIndex].Length;
        var counter = 0;
        for (var i = rowIndex; i < rowLength; i++)
        {
            if (mat[colIndex][i] == 0)
                break;

            counter++;
        }

        max = counter > max ? counter : max;
    }

    private void GoOnCol(int[][] mat, int colIndex, int rowIndex)
    {
        var colLength = mat.Length;
        var counter = 0;
        for (var i = colIndex; i < colLength; i++)
        {
            if (mat[i][rowIndex] == 0)
                break;

            counter++;
        }

        max = counter > max ? counter : max;
    }

    private void GoOnDiagonal(int[][] mat, int colIndex, int rowIndex)
    {
        var colLength = mat.Length;
        var rowLength = mat[0].Length;
        var counter = 0;
        for (var i = colIndex; i < colLength; i++)
        {
            if (rowIndex >= rowLength)
                break;

            if (mat[i][rowIndex] == 0)
                break;

            counter++;
            rowIndex++;
        }

        max = counter > max ? counter : max;
    }

    private void GoOnAntiDiagonal(int[][] mat, int colIndex, int rowIndex)
    {
        var colLength = mat.Length;
        var rowLength = mat[0].Length;
        var counter = 0;
        for (var i = colIndex; i < colLength; i++)
        {
            if (rowIndex < 0)
                break;

            if (mat[i][rowIndex] == 0)
                break;

            counter++;
            rowIndex--;
        }

        max = counter > max ? counter : max;
    }
}