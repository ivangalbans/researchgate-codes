using System;
using System.Collections.Generic;
namespace _1085
{
    class Program
    {
        struct node
        {
            public int num, index, idx;
        }
        static node[] a;
        static int n;
        static int MOD = 1000000007;

        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int tc = 1; tc <= T; tc++)
            {
                n = int.Parse(Console.ReadLine());
                a = new node[n + 1];
                string[] data = Console.ReadLine().Split();

                for (int i = 1; i <= n; i++)
                {
                    a[i].num = int.Parse(data[i - 1]);
                    a[i].index = i;
                }

                int len = compress();
                Fenwick_Tree ft = new Fenwick_Tree(len);

                int ans = 0;
                for (int i = 1; i <= n; i++)
                {
                    int freq = ft.query(a[i].idx - 1);
                    ans = (ans + freq + 1) % MOD;
                    ft.update(a[i].idx, freq + 1);
                }
                Console.WriteLine("Case {0}: {1}", tc, ans);
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

            internal int query(int pos)
            {
                int sum = 0;
                for (; pos > 0; pos -= lowbit(pos))
                    sum = (sum + ft[pos]) % MOD;
                return sum;
            }

            internal void update(int pos, int val)
            {
                val = val % MOD;
                for (; pos <= _n; pos += lowbit(pos))
                    ft[pos] = (ft[pos] + val) % MOD;
            }
        }

        class cmp_n : IComparer<node>
        {
            public int Compare(node x, node y)
            {
                return x.num.CompareTo(y.num);
            }
        }
        class cmp_ind : IComparer<node>
        {
            public int Compare(node x, node y)
            {
                return x.index.CompareTo(y.index);
            }
        }

        private static int compress()
        {
            cmp_n cmp_num = new cmp_n();
            Array.Sort(a, 1, n, cmp_num);
            a[1].idx = 1;

            for (int i = 2; i <= n; i++)
            {
                if (a[i].num == a[i - 1].num)
                    a[i].idx = a[i - 1].idx;
                else
                    a[i].idx = a[i - 1].idx + 1;
            }

            int len = a[n].idx;
            cmp_ind cmp_index = new cmp_ind();
            Array.Sort(a, 1, n, cmp_index);

            return len;
        }
    }
}
