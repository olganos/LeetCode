﻿using System;

namespace Number_of_Operations_to_Make_Network_Connected
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-operations-to-make-network-connected/
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();

            // Input: n = 4, connections = [[0,1],[0,2],[1,2]]
            // Output: 1
            Console.WriteLine(solution.MakeConnected(4, new int[][]
            {
                new []{0,1},
                new []{0,2},
                new []{1,2}
            }));
            Console.WriteLine();

            // Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2],[1,3]]
            // Output: 2
            Console.WriteLine(solution.MakeConnected(6, new int[][]
            {
                new []{0,1},
                new []{0,2},
                new []{0,3},
                new []{1,2},
                new []{1,3}
            }));
            Console.WriteLine();

            // Input: n = 6, connections = [[0,1],[0,2],[0,3],[1,2]]
            // Output: -1
            Console.WriteLine(solution.MakeConnected(6, new int[][]
            {
                new []{0,1},
                new []{0,2},
                new []{0,3},
                new []{1,2}
            }));
            Console.WriteLine();

            // Input: n = 5, connections = [[0,1],[0,2],[3,4],[2,3]]
            // Output: 0
            Console.WriteLine(solution.MakeConnected(5, new int[][]
            {
                new []{0,1},
                new []{0,2},
                new []{3,4},
                new []{2,3}
            }));
            Console.WriteLine();
        }
    }

    public class Solution
    {
        public int MakeConnected(int n, int[][] connections)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException();

            // todo: check, id int[i].Legnth > 2 and others

            int extraConnections = 0;
            int root = 0;
            // var union = new QuickFind(n);
            var union = new WeightedQuickUnion(n);
            for (var i = 0; i < connections.Length; i++)
            {
                if (union.Connected(connections[i][0], connections[i][1]))
                    extraConnections++;
                else
                {
                    root = union.Union(connections[i][0], connections[i][1]); ;
                }
            }

            // iteration via ids
            var extraConnectionsCounter = 0;
            for (var i = 0; i < n; i++)
            {
                if (!union.Connected(i, root))
                {
                    root = union.Union(i, root);
                    extraConnectionsCounter++;
                    extraConnections--;
                    if (extraConnections < 0)
                        return -1;
                }
            }
            return extraConnections < 0 ? -1 : extraConnectionsCounter;
        }
    }
}
