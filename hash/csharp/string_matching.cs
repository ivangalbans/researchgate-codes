using System;
namespace string_matching
{
    class Program
    {
        static int MAXN = 100005;
        static long[] prime = new long[MAXN];
        static long[] fh = new long[MAXN];
        static long mod = 1000000009;
        static long x = 1223;
        static void compute_hash(string s)
        {
            for (int i = 1; i <= s.Length; i++)
                fh[i] = (fh[i - 1] + s[i - 1] * prime[i]) % mod;
        }
        static long get_subtring_hash(int l, int r)
        {
            ++l;++r;
            return (fh[r] - fh[l-1] + mod) % mod;
        }
        static long get_hash(string s)
        {
            long ret = 0;
            for (int i = 0; i < s.Length; i++)
                ret = (ret + s[i] * prime[i+1]) % mod;
            return ret;
        }
        static void Main(string[] args)
        {
            string t = Console.ReadLine();
            string p = Console.ReadLine();

            prime[0] = 1;
            for (int i = 1; i < MAXN; i++)
                prime[i] = (prime[i - 1] * x) % mod;

            compute_hash(t);

            int n = t.Length;
            int m = p.Length;
            long hp = get_hash(p);
            int match = 0;

            for (int i = 0; i < n-m+1; i++)
                if (get_subtring_hash(i, i + m - 1) == (hp*prime[i]) % mod)
                    match++;
            Console.WriteLine(match);
        }
    }
}