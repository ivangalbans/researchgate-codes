#include <bits/stdc++.h>
using namespace std;

#define MAXN 50000
#define H first
#define W second

typedef pair<int, int> pii;
typedef long long ll;

struct line
{
	ll m, b;
	line(ll m, ll b) : m(m), b(b) {}
};

int N;
pii a[MAXN];
pii rect[MAXN];

struct ConvexHullTrick
{

	int len, ptr;
	vector<line> r;
	ConvexHullTrick(int n)
	{
		r.assign(n, line(0, 0));
		ptr = len = 0;
	}

	bool bad(line l1, line l2, line l3)
	{
		return (l3.b - l1.b) * (l1.m - l2.m) <
					 (l2.b - l1.b) * (l1.m - l3.m);
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

	cin >> N;
	for (int i = 0; i < N; ++i)
		cin >> a[i].H >> a[i].W;
	sort(a, a + N);

	int len = 0;
	for (int i = 0; i < N; ++i)
	{
		while (len > 0 && rect[len - 1].W <= a[i].W)
			--len;
		rect[len++] = a[i];
	}

	ll cost[len + 1];
	cost[0] = 0;
	ConvexHullTrick cht(len);
	cht.add(line(rect[0].W, cost[0]));

	for (int i = 0; i < len; ++i)
	{
		cost[i + 1] = cht.query(rect[i].H);
		if (i < len - 1)
			cht.add(line(rect[i + 1].W, cost[i + 1]));
	}

	cout << cost[len] << endl;

	return 0;
}
