using System;
using System.Collections.Generic;
namespace _2590
{
    class Program
    {
        struct node
        {
            public int num, index, idx;
        }
        static node[] a;
        static int n, K;
        static int MOD = 5000000;

        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split();
            n = int.Parse(data[0]);
            K = int.Parse(data[1]);

            a = new node[n];
            for (int i = 0; i < n; i++)
            {
                a[i].num = int.Parse(Console.ReadLine());
                a[i].index = i;
            }

            int len = compress();
            Fenwick_Tree[] f = new Fenwick_Tree[K + 1];
            for (int i = 0; i <= K; ++i)
                f[i] = new Fenwick_Tree(len);

            int ans = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int k = 1; k <= K; ++k)
                {
                    int val;
                    if (k - 1 == 0)
                        val = 1;
                    else
                        val = f[k - 1].query(a[i].idx - 1);

                    f[k].update(a[i].idx, val);

                    if (k == K)
                        ans = (ans + val) % MOD;
                }
            }
            Console.WriteLine(ans);

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
            Array.Sort(a, cmp_num);
            a[0].idx = 1;

            for (int i = 1; i < n; i++)
            {
                a[i].idx = a[i - 1].idx;
                if (a[i - 1].num != a[i].num)
                    ++a[i].idx;
            }

            int len = a[n - 1].idx;
            cmp_ind cmp_index = new cmp_ind();
            Array.Sort(a, cmp_index);

            return len;
        }
    }
}
