using System;
using System.ComponentModel.Design.Serialization;

namespace Number_of_Operations_to_Make_Network_Connected
{
    public class WeightedQuickUnion
    {
        private int[] Ids { get; set; }
        private int[] sizes { get; set; }
        private int _size;

        public WeightedQuickUnion(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException();

            _size = n;
            sizes = new int[n];
            Ids = new int[n];
            for (var i = 0; i < n; i++)
            {
                Ids[i] = i;
            }
        }

        public bool Connected(int p, int q)
        {
            if (p >= _size || q >= _size)
                throw new ArgumentOutOfRangeException();

            return Root(Ids[p]) == Root(Ids[q]);
        }

        private int Root(int index)
        {
            while (index != Ids[index])
                index = Ids[index];

            return index;
        }

        /// <summary>
        /// return current root
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public int Union(int p, int q)
        {
            if (p >= _size || q >= _size)
                throw new ArgumentOutOfRangeException();

            var rootP = Root(Ids[p]);
            var rootQ = Root(Ids[q]);

            if (rootP == rootQ)
                return rootQ;
            if (rootP < rootQ)
            {
                Ids[rootP] = Ids[rootQ];
                sizes[rootQ] += sizes[rootP];
                return rootQ;
            }

            Ids[rootQ] = Ids[rootP];
            sizes[rootP] += sizes[rootQ];
            return rootP;
        }
    }
}