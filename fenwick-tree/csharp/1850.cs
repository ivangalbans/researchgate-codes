using System;
namespace _1850___Again_Making_Queries_II
{
    class Program
    {
        static int MOD = 10000;
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            int N = int.Parse(data[0]);
            int U = int.Parse(data[1]);
            int Q = int.Parse(data[2]);

            Fenwick_Tree ft = new Fenwick_Tree(N);

            for (int i = 0; i < U + Q; i++)
            {
                data = Console.ReadLine().Split();
                int op = int.Parse(data[0]);
                int u = int.Parse(data[1]);
                int v = int.Parse(data[2]);

                if (op == 1)
                {
                    ft.update(u, 2 * v);
                    if (u != 1)
                        ft.update(u - 1, v);
                    if (u != N)
                        ft.update(u + 1, v);
                }
                else
                {
                    Console.WriteLine(ft.query(u, v));
                }
            }
        }
        private class Fenwick_Tree
        {
            private int _n;
            private int[] ft;

            public Fenwick_Tree(int n)
            {
                _n = n;
                ft = new int[_n + 1];
            }
            private int lowbit(int v)
            {
                return v & (-v);
            }
            internal long query(int u, int v)
            {
                long sum = query(v) - query(u - 1);
                if (sum < 0)
                    sum += MOD;
                return sum;
            }
            private long query(int pos)
            {
                long sum = 0;
                for (; pos > 0; pos -= lowbit(pos))
                    sum = (sum + ft[pos]) % MOD;
                return sum;
            }
            internal void update(int pos, int val)
            {
                for (; pos <= _n; pos += lowbit(pos))
                    ft[pos] = (ft[pos] + val) % MOD;
            }
        }
    }
}