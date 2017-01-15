static long hash(string s, long x = 1223, long MOD = 1000000009)
{
    long[] h = new long[s.Length];
    long[] pow = new long[s.Length];
    pow[0] = 1; h[0] = s[0];
    for (int i = 1; i < s.Length; ++i)
    {
        pow[i] = (pow[i - 1] * x) % MOD;
        h[i] = (h[i - 1] + s[i] * pow[i]) % MOD;
    }
    return h[s.Length - 1];
}