static void Main(string[] args)
{
    fh = new long[MAXN];
    bh = new long[MAXN];
    prime = new long[MAXN];

    string s = Console.ReadLine();
    n = s.Length;
    prime_power(s.Length);
    compute_hash(s);

    int cont = 0;
    for (int i = 0; i < n-1; ++i)
        if (subtring_palindrome(0, i) && subtring_palindrome(i + 1, n - 1))
            ++cont;
    if (subtring_palindrome(0, n - 1))
        cont += 2;

    Console.WriteLine(cont);
}