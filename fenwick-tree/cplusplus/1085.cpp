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
const int MOD = 1000000007;
/////////////////////////////////////////////////

const int
		MaxN = 100005;

int n;

struct node
{
	int num, index, idx;
};

node a[MaxN];

struct abi
{

	vector<int> ft;
	abi(int len) : ft(len + 1, 0) {}

	int lowbit(int x) { return x & -x; }

	void update(int pos, int val)
	{
		val = val % MOD;
		for (; pos < (int)ft.size(); pos += lowbit(pos))
			ft[pos] = (ft[pos] + val) % MOD;
	}

	int query(int pos)
	{
		int sum = 0;
		for (; pos > 0; pos -= lowbit(pos))
			sum = (sum + ft[pos]) % MOD;
		return sum;
	}
};

bool cmp_num(node a, node b)
{
	return a.num < b.num;
}

bool cmp_index(node a, node b)
{
	return a.index < b.index;
}

int compress()
{
	sort(a + 1, a + n + 1, cmp_num);
	a[1].idx = 1;

	for (int i = 2; i <= n; ++i)
	{
		if (a[i].num == a[i - 1].num)
			a[i].idx = a[i - 1].idx;
		else
			a[i].idx = a[i - 1].idx + 1;
	}
	int len = a[n].idx;
	sort(a + 1, a + n + 1, cmp_index);
	return len;
}

int main()
{
	//ios_base::sync_with_stdio(false);
	//cin.tie(0);

	int t;
	scanf("%d", &t);
	for (int cs = 1; cs <= t; ++cs)
	{
		scanf("%d", &n);
		for (int i = 1; i <= n; ++i)
		{
			scanf("%d", &a[i].num);
			a[i].index = i;
		}

		int len = compress();
		abi ft(len);

		int ans = 0;
		for (int i = 1; i <= n; ++i)
		{
			int freq = ft.query(a[i].idx - 1);
			ans = (ans + freq + 1) % MOD;
			ft.update(a[i].idx, freq + 1);
		}
		printf("Case %d: %d\n", cs, ans);
	}

	return 0;
}
