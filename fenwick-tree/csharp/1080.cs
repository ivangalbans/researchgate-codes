using System;
namespace _1080___Binary_Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            string bits;

            for (int tc = 1; tc <= T; tc++)
            {
                bits = Console.ReadLine();
                Fenwick_Tree ft = new Fenwick_Tree(bits.Length);

                Console.WriteLine("Case {0}:", tc);
                int q = int.Parse(Console.ReadLine());
                for (int i = 0; i < q; i++)
                {
                    string[] data = Console.ReadLine().Split();
                    if (data[0] == "I")
                    {
                        int l = int.Parse(data[1]);
                        int r = int.Parse(data[2]);
                        ft.update(l, r, 1);
                    }
                    else
                    {
                        int pos = int.Parse(data[1]);
                        int bit = int.Parse(bits[pos - 1].ToString());
                        Console.WriteLine(bit ^ ft.query(pos));
                    }
                }
            }
        }
        private class Fenwick_Tree
        {
            private int _n;
            private int[] ft;
            public Fenwick_Tree(int n)
            {
                _n = n;
                ft = new int[_n + 1];
            }
            private int lowbit(int v)
            {
                return v & (-v);
            }
            internal int query(int pos)
            {
                int xor = 0;
                for (; pos > 0; pos -= lowbit(pos))
                    xor ^= ft[pos];
                return xor;
            }
            private void update(int pos, int val)
            {
                for (; pos <= _n; pos += lowbit(pos))
                    ft[pos] ^= val;
            }
            internal void update(int l, int r, int val)
            {
                update(l, val);
                update(r + 1, val);
            }

        }
    }
}
