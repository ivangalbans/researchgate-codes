#include <bits/stdc++.h>
using namespace std;

#define MAXN 1e5;
#define endl '\n'
#define DB(x) cout << #x << " = " << x << endl;

typedef long long ll;

struct line
{
	ll m, b;
	line(ll m, ll b) : m(m), b(b) {}
};

struct ConvexHullTrick
{

	int len, ptr;
	vector<line> r;

	ConvexHullTrick(int n)
	{
		len = ptr = 0;
		r.assign(n, line(0, 0));
	}

	bool bad(line l1, line l2, line l3)
	{
		return (double)(l3.b - l1.b) / (l1.m - l3.m) <
					 (double)(l2.b - l1.b) / (l1.m - l2.m);
	}

	void add(line x)
	{
		while (len >= 2 && bad(r[len - 2], r[len - 1], x))
			--len;
		r[len++] = x;
	}

	ll query(int x)
	{
		ptr = min(ptr, len - 1);
		while (ptr + 1 < len && r[ptr + 1].m * x +
																		r[ptr + 1].b <
																r[ptr].m * x + r[ptr].b)
			++ptr;
		return r[ptr].m * x + r[ptr].b;
	}
};

int main()
{

	ios_base::sync_with_stdio(0);
	cin.tie(0);

	int n;
	cin >> n;
	int a[n + 1], b[n + 1];
	ll dp[n + 1];

	for (int i = 1; i <= n; ++i)
		cin >> a[i];
	for (int i = 1; i <= n; ++i)
		cin >> b[i];

	ConvexHullTrick cht(n);
	dp[1] = a[1] * b[1];
	cht.add(line(b[1], 0));
	for (int i = 2; i <= n; ++i)
	{
		dp[i] = cht.query(a[i]);
		cht.add(line(b[i], dp[i]));
	}
	cout << dp[n] << endl;

	return 0;
}
