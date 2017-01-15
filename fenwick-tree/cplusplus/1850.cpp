#include <bits/stdc++.h>

#define endl '\n'
#define MOD 10000

using namespace std;

typedef long long Int;

template <class T>
struct BIT
{

  vector<T> ft;
  BIT(int n) : ft(n, 0) {}

  void Update(int pos, int val)
  {
    for (; pos <= ft.size(); pos += pos & (-pos))
      ft[pos] = (ft[pos] + val) % MOD;
  }

  Int Query(int pos)
  {
    Int sum = 0;

    for (; pos > 0; pos -= pos & (-pos))
      sum = (sum + ft[pos]) % MOD;
    return sum;
  }

  Int Query(int a, int b)
  {
    Int sum = Query(b) - Query(a - 1);

    if (sum < 0)
      sum += MOD;
    return sum;
  }
};

int main()
{
  ios_base::sync_with_stdio(0);
  cin.tie(0);

  int N, U, Q;
  cin >> N >> U >> Q;
  BIT<int> A(N + 1);

  for (int i = 0; i < U + Q; i++)
  {
    int op, u, v;
    cin >> op >> u >> v;

    if (op == 1)
    {
      A.Update(u, 2 * v);
      if (u != 1)
        A.Update(u - 1, v);
      if (u != N)
        A.Update(u + 1, v);
    }

    else
    {
      cout << A.Query(u, v) << endl;
    }
  }

  return 0;
}
