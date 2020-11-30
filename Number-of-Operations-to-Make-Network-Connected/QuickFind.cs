using System;

namespace Number_of_Operations_to_Make_Network_Connected
{
    public class QuickFind
    {
        private int[] Ids { get; set; }
        private int _size;

        public QuickFind(int n)
        {
            if (n <= 0)
                throw new ArgumentOutOfRangeException();

            _size = n;
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

            return Ids[p] == Ids[q];
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

            var rootP = Ids[p];
            var rootQ = Ids[q];
            for (var i = 0; i < _size; i++)
            {
                if (Ids[i] == rootP || Ids[i] == rootQ)
                    Ids[i] = rootQ;
            }

            return rootQ;
        }
    }
}