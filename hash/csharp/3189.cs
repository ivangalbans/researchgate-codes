using System;
namespace _3189
{
    class Program
    {
        static long mod = 1000000000 + 9;
        static long x = 3, y = 5;
        static int MAXN = 2005;
        static string[] t = new string[MAXN];
        static string[] p = new string[MAXN];
        static int nt, mt, np, mp;
        static long[,] ht = new long[MAXN, MAXN];
        static long[,] prime = new long[2, MAXN];

        static long mmod(long a, long b)
        {
            return (a * b) % mod;
        }
        static void compute_hash()
        {
            for (int i = 1; i <= nt; ++i)
                for (int j = 1; j <= mt; ++j)
                    ht[i, j] = (((mmod(t[i - 1][j - 1], 
                        mmod(prime[0, i], prime[1, j])) +
                            ht[i - 1, j] + ht[i, j - 1]) % mod) -
                                ht[i - 1, j - 1] + mod) % mod;
        }
        static long patron_hash()
        {
            long hp = 0;
            for (int i = 1; i <= np; ++i)
                for (int j = 1; j <= mp; ++j)
                    hp = (hp + p[i - 1][j - 1] *
                        mmod(prime[0, i], prime[1, j])) % mod;
            return hp;
        }
        static long accumulate(int f, int c)
        {
            return ((ht[f, c] - ht[f - np, c] - ht[f, c - mp] +
                    ht[f - np, c - mp]) + 3 * mod) % mod;
        }
        static int solve(long hp)
        {
            int match = 0;
            for (int i = np; i <= nt; ++i)
                for (int j = mp; j <= mt; ++j)
                    if (accumulate(i, j) == mmod(hp,
                        mmod(prime[0, i - np], prime[1, j - mp])))
                        ++match;
            return match;
        }
        static void Main(string[] args)
        {
            prime[0, 0] = 1;
            prime[1, 0] = 1;
            for (int i = 1; i < MAXN; ++i)
            {
                prime[0, i] = (prime[0, i - 1] * x) % mod;
                prime[1, i] = (prime[1, i - 1] * y) % mod;
            }

            int[] data = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            np = data[0];   mp = data[1];
            nt = data[2];   mt = data[3];

            for (int i = 0; i < np; ++i)
                p[i] = Console.ReadLine();
            for (int i = 0; i < nt; ++i)
                t[i] = Console.ReadLine();

            compute_hash();
            long hp = patron_hash();

            Console.WriteLine(solve(hp));
        }
    }
}
