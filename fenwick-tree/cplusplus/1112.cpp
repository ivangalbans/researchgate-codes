#include <bits/stdc++.h>

using namespace std;

/////////////////////////////////////////////////
typedef long long Int;
typedef pair<int, int> pii;
typedef vector<int> vi;
/////////////////////////////////////////////////
#define REP(i, n) \
	for (int i = 0; i < (int)n; ++i)
#define FOR(i, n) \
	for (int i = 1; i <= (int)n; ++i)
#define ITR(c) __typeof((c).begin())
#define foreach(i, c) \
	for (ITR(c) i = (c).begin(); i != (c).end(); ++i)
#define ALL(c) \
	(c).begin(), (c).end()
#define DB(x) \
	cout << #x << " = " << x << endl

#define endl '\n'
#define F first
#define S second
#define pb push_back
#define mp make_pair
#define LEFT(n) ((n << 1) + 1)
#define RIGHT(n) ((n << 1) + 2)
#define BIT(n) (1 << n)
#define ONES(n) __builtin_popcount(n)
#define rightZero(n) __builtin_ctz(n); // trailing zeros
#define leftZero(n) __builtin_clz(n);	// leading zeros

/////////////////////////////////////////////////
const double EPS = 1e-15;
const int oo = (1 << 30);
const double PI = M_PI;
const int MOD = 1000000000 + 7;
/////////////////////////////////////////////////

const int
		MaxN = 100001;

struct abi
{

	vector<int> ft;
	abi(int len) : ft(len + 1, 0) {}

	int lowbit(int x) { return x & -x; }

	void update(int pos, int val)
	{
		for (; pos < (int)ft.size(); pos += lowbit(pos))
			ft[pos] += val;
	}

	int query(int pos)
	{
		int sum = 0;
		for (; pos > 0; pos -= lowbit(pos))
			sum += ft[pos];
		return sum;
	}

	int query(int l, int r)
	{
		l = (l > 0) ? l - 1 : 0;
		return query(r) - query(l);
	}
};

int main()
{
	//ios_base::sync_with_stdio(false);
	//cin.tie(0);

	int t;
	scanf("%d", &t);
	for (int cs = 1; cs <= t; ++cs)
	{
		int n, q;
		scanf("%d %d", &n, &q);
		abi f(n);

		for (int i = 0; i < n; ++i)
		{
			int ni;
			scanf("%d", &ni);
			f.update(i + 1, ni);
		}

		printf("Case %d:\n", cs);
		for (int i = 0; i < q; ++i)
		{
			int op;
			scanf("%d", &op);

			if (op == 1)
			{
				int pos;
				scanf("%d", &pos);
				int sack = f.query(pos + 1, pos + 1);

				f.update(pos + 1, -sack);
				printf("%d\n", sack);
			}
			else if (op == 2)
			{
				int pos, val;
				scanf("%d %d", &pos, &val);
				f.update(pos + 1, val);
			}
			else
			{
				int l, r;
				scanf("%d %d", &l, &r);
				printf("%d\n", f.query(l + 1, r + 1));
			}
		}
	}

	return 0;
}
