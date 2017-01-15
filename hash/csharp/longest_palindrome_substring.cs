static bool palindrome_substring_length_k(int k)
{
    if (k == 0)
        return true;
    for (int i = k - 1; i < n; ++i)
        if (subtring_palindrome(i - k + 1, i))
            return true;
    return false;
}

static int binary_search(int parity)
{
    int l = 1, r = n;
    while(l <= r)
    {
        int m = (l + r) / 2;
        if (m % 2 != parity)
            m--;
        if (palindrome_substring_length_k(m))
            l = m + 2;
        else
            r = m - 1;                
    }
    return l-2;
}
static void Main(string[] args)
{
    fh = new long[MAXN];
    bh = new long[MAXN];
    prime = new long[MAXN];

    string s = Console.ReadLine();
    n = s.Length;
    prime_power(n);
    compute_hash(s);

    Console.WriteLine(Math.Max(binary_search(0), binary_search(1)));
}