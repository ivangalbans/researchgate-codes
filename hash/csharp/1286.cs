static bool solve()
{
    if (n % 2 == 1)
        return false;

    int ptr_ = 0;
    for (int i = 1; i < n; ++i)
    {
        if(s[i] == s[i-1])
        {
            int _ptr = i + i - ptr_ - 1;
            if (_ptr < n && substring_palindrome(ptr_, _ptr))
                ptr_ = i = _ptr + 1;
        }
    }
    return ptr_ == n;
}
static void Main(string[] args)
{
    prime_power();
    int T = int.Parse(Console.ReadLine());
    for (int i = 0; i < T; i++)
    {
        s = Console.ReadLine();
        n = s.Length;
        compute_hash();
        Console.WriteLine("{0}", solve() ? "YES" : "NO");
    }
}