using System;
namespace acquire
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            Tuple<int, int>[] a = new Tuple<int, int>[N];
            Tuple<int, int>[] rect = new Tuple<int, int>[N];
            
            for (int i = 0; i < N; ++i)
            {
                string[] data = Console.ReadLine().Split();
                a[i] = new Tuple<int, int>(int.Parse(data[0]), int.Parse(data[1]));
            }
            Array.Sort(a);

            int len = 0;
            for (int i = 0; i < N; ++i)
            {
                while (len > 0 && rect[len - 1].Item2 <= a[i].Item2)
                    --len;
                rect[len++] = a[i];
            }

            long[] cost = new long[len + 1];
            cost[0] = 0;
            ConvexHullTrick cht = new ConvexHullTrick(len);
            cht.add(new line(rect[0].Item2, cost[0]));

            for (int i = 0; i < len; ++i)
            {
                cost[i + 1] = cht.query(rect[i].Item1);
                if (i < len - 1)
                    cht.add(new line(rect[i + 1].Item2, cost[i + 1]));
            }

            Console.WriteLine(cost[len]);
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
