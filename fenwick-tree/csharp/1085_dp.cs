using System;
namespace _1085_dp
{
    class Program
    {
        static void Main(string[] args)
        {
            int MOD = 1000000007;
            int T = int.Parse(Console.ReadLine());
            for (int tc = 1; tc <= T; tc++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                int[] dp = new int[n];

                int count_is = dp[0] = 1;
                for (int i = 1; i < n; i++)
                {
                    dp[i] = 1;
                    for (int j = 0; j < i; j++)
                        if (a[i] > a[j])
                            dp[i] = (dp[i] + dp[j]) % MOD;
                    count_is = (count_is + dp[i]) % MOD;
                }
                Console.WriteLine("Case {0}: {1}", tc, count_is);
            }
        }
    }
}
