using System;
using System.Collections.Generic;
namespace _3734
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
            int t = int.Parse(Console.ReadLine());
            while (t-- > 0)
            {
                n = int.Parse(Console.ReadLine());
                a = new node[n];
                string[] data = Console.ReadLine().Split();

                for (int i = 0; i < n; i++)
                {
                    a[i].num = int.Parse(data[i]);
                    a[i].index = i;
                }

                int len = compress();
                Fenwick_Tree even = new Fenwick_Tree(len);
                Fenwick_Tree odd = new Fenwick_Tree(len);


                int ans = 0;
                for (int i = 0; i < n; i++)
                {
                    int par = even.query(a[i].idx - 1);
                    int imp = odd.query(a[i].idx - 1);

                    if (a[i].num % 2 == 0)
                    {
                        ans = (ans + imp) % MOD;
                        even.update(a[i].idx, par + 1);
                        odd.update(a[i].idx, imp);
                    }
                    else
                    {
                        ans = (ans + par + 1) % MOD;
                        even.update(a[i].idx, imp);
                        odd.update(a[i].idx, par + 1);
                    }
                }
                Console.WriteLine(ans);
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
