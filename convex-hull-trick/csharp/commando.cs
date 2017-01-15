using System;
namespace comando
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            while (T --> 0)
            {
                int n = int.Parse(Console.ReadLine());
                long[] x = new long[n + 1];
                long[] sum = new long[n + 1];
                long[] dp = new long[n + 1];
                string[] data = Console.ReadLine().Split();
                int a = int.Parse(data[0]);
                int b = int.Parse(data[1]);
                int c = int.Parse(data[2]);

                data = Console.ReadLine().Split();
                for (int i = 1; i <= n; ++i)
                {
                    x[i] = long.Parse(data[i-1]);
                    sum[i] = sum[i - 1] + x[i];
                }

                ConvexHullTrick cht = new ConvexHullTrick(n);

                dp[1] = a * sq(x[1]) + b * x[1] + c;
                cht.add(new line(-2 * a * sum[1], dp[1] +
                            a * sq(sum[1]) - b * sum[1]));

                for (int i = 2; i <= n; ++i)
                {
                    dp[i] = a * sq(sum[i]) + b * sum[i] + c;
                    dp[i] = Math.Max(dp[i], dp[i] + cht.query(sum[i]));
                    cht.add(new line(-2 * a * sum[i], dp[i] +
                                a * sq(sum[i]) - b * sum[i]));
                }
                Console.WriteLine(dp[n]);
            }
        }

        private static long sq(long x)
        {
            return x*x;
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
                return (l3.b - l1.b) * (l1.m - l2.m) <
                       (l2.b - l1.b) * (l1.m - l3.m);
            }

            internal void add(line x)
            {
                while (len >= 2 && bad(r[len - 2], r[len - 1], x))
                    --len;
                r[len++] = x;
            }

            internal long query(long x)
            {
                ptr = Math.Min(ptr, len - 1);
                while (ptr + 1 < len && r[ptr + 1].m * x +
                        r[ptr + 1].b >= r[ptr].m * x + r[ptr].b)
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
