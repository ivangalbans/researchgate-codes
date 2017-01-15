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
const int MOD = 5000000;
/////////////////////////////////////////////////

const int
		MaxN = 10001;

int N, K;

struct node
{
	int num, index, idx;
};

node a[MaxN];

struct abi
{

	vector<int> ft;
	abi() {}
	abi(int len) : ft(len + 1, 0) {}

	int lowbit(int x) { return x & -x; }

	void update(int pos, int val)
	{
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

bool cmp_num(node uno, node dos)
{
	return uno.num < dos.num;
}

bool cmp_index(node uno, node dos)
{
	return uno.index < dos.index;
}

int compress()
{
	sort(a, a + N, cmp_num);
	a[0].idx = 1;

	for (int i = 1; i < N; ++i)
	{
		a[i].idx = a[i - 1].idx;
		if (a[i - 1].num != a[i].num)
			++a[i].idx;
	}

	int len = a[N - 1].idx;
	sort(a, a + N, cmp_index);
	return len;
}

int main()
{
	ios_base::sync_with_stdio(false);
	cin.tie(0);

	cin >> N >> K;
	for (int i = 0; i < N; ++i)
	{
		cin >> a[i].num;
		a[i].index = i;
	}

	int len = compress();
	vector<abi> f(K + 1);
	for (int i = 0; i <= K; ++i)
		f[i] = abi(len);

	int ans = 0;

	for (int i = 0; i < N; ++i)
	{
		for (int k = 1; k <= K; ++k)
		{
			int val;
			if (k - 1 == 0)
				val = 1;
			else
				val = f[k - 1].query(a[i].idx - 1);

			f[k].update(a[i].idx, val);

			if (k == K)
				ans = (ans + val) % MOD;
		}
	}

	cout << ans << endl;

	return 0;
}
