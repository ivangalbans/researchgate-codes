using System;
using System.Collections.Generic;
namespace Watto
{
    class Program
    {
        static long MOD = 1000000009,
                      N = 1000001,
                      A = 11;
        static int n, m;
        static long[] bas = new long[N];
        static SortedSet<long> S = new SortedSet<long>();
        static string t;

        static void Main(string[] args)
        {
            bas[0] = 1;
            for (int i = 1; i < N; ++i)
                bas[i] = (bas[i - 1] * A) % MOD;

            string[] data = Console.ReadLine().Split();
            n = int.Parse(data[0]);
            m = int.Parse(data[1]);
            while (n-- > 0)
            {
                t = Console.ReadLine();
                S.Add(get_hash(t));
            }
            while (m-- > 0)
            {
                bool ok = false;
                t = Console.ReadLine();
                long h = get_hash(t);
                for (int i = 0; i < t.Length; ++i)
                    for (int j = 'a'; j <= 'c'; ++j)
                        if (j != t[i])
                            ok |= S.Contains(((h + (j - t[i]) * bas[i]) + 4 * MOD) % MOD);
                Console.WriteLine("{0}", (ok ? "YES" : "NO"));
            }
        }
        private static long get_hash(string s)
        {
            long ret = 0;
            for(int i = 0; i < s.Length; ++i)
            {
                ret += s[i] * bas[i];
                ret %= MOD;
            }
            return ret;
        }
    }
}
