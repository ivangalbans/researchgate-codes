using System;
namespace _1112___Curious_Robin_Hood
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            string[] data;
            int n, q;

            for (int tc = 1; tc <= T; tc++)
            {
                data = Console.ReadLine().Split();
                n = int.Parse(data[0]);
                q = int.Parse(data[1]);

                Fenwick_Tree ft = new Fenwick_Tree(n);

                data = Console.ReadLine().Split();
                for (int i = 1; i <= n; i++)
                    ft.update(i, int.Parse(data[i - 1]));

                Console.WriteLine("Case {0}:", tc);
                for (int i = 0; i < q; i++)
                {
                    data = Console.ReadLine().Split();
                    if (data[0] == "1")
                    {
                        int pos = int.Parse(data[1]) + 1;
                        int sack = ft.query(pos, pos);
                        ft.update(pos, -sack);
                        Console.WriteLine(sack);
                    }
                    else if (data[0] == "2")
                    {
                        int pos = int.Parse(data[1]) + 1;
                        int val = int.Parse(data[2]);
                        ft.update(pos, val);
                    }
                    else
                    {
                        int l = int.Parse(data[1]) + 1;
                        int r = int.Parse(data[2]) + 1;
                        Console.WriteLine(ft.query(l, r));
                    }
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
            internal int query(int u, int v)
            {
                return query(v) - query(u - 1);
            }
            private int query(int pos)
            {
                int sum = 0;
                for (; pos > 0; pos -= lowbit(pos))
                    sum += ft[pos];
                return sum;
            }
            internal void update(int pos, int val)
            {
                for (; pos <= _n; pos += lowbit(pos))
                    ft[pos] += val;
            }
        }
    }
}
