static void Main(string[] args)
{
    fh = new long[MAXN];
    bh = new long[MAXN];
    prime = new long[MAXN];

    int k = int.Parse(Console.ReadLine());
    string s = Console.ReadLine();
    n = s.Length;
    prime_power(s.Length);
    compute_hash(s);

    int count = 0;
    for (int i = k - 1; i < n; ++i)
        if (subtring_palindrome(i - k + 1, i))
            ++count;
    Console.WriteLine(count);
}