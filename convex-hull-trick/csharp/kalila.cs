using System;
namespace Kalila_Dimna
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n + 1];
            int[] b = new int[n + 1];
            long[] dp = new long[n + 1];

            int[] tmp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int i = 1; i <= n; i++) a[i] = tmp[i - 1];
            tmp = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            for (int i = 1; i <= n; i++) b[i] = tmp[i - 1];

            ConvexHullTrick cht = new ConvexHullTrick(n);
            dp[1] = a[1] * b[1];
            cht.add(new line(b[1], 0));
            for (int i = 2; i <= n; ++i)
            {
                dp[i] = cht.query(a[i]);
                cht.add(new line(b[i], dp[i]));
            }

            Console.WriteLine(dp[n]);
        }

        private class ConvexHullTrick
        {
            private int len, ptr;
            line[] r;

            public ConvexHullTrick(int n)
            {
                r = new line[n];
                ptr = len = 0;
            }

            bool bad(line l1, line l2, line l3)
            {
                return (double)(l3.b - l1.b) / (l1.m - l3.m) <
                       (double)(l2.b - l1.b) / (l1.m - l2.m);
            }

            internal void add(line x)
            {
                while (len >= 2 && bad(r[len - 2], r[len - 1], x))
                    --len;
                r[len++] = x;
            }

            internal long query(int x)
            {
                ptr = Math.Min(ptr, len - 1);
                while (ptr + 1 < len && r[ptr + 1].m * x +
                        r[ptr + 1].b < r[ptr].m * x + r[ptr].b)
                    ++ptr;
                return r[ptr].m * x + r[ptr].b;
            }
        }
        private class line
        {
            public long m, b;

            public line(long _m, long _b)
            {
                m = _m;
                b = _b;
            }
        }
    }
}
