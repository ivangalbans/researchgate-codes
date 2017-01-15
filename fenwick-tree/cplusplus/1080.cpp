#include <bits/stdc++.h>

using namespace std;

const int
		MaxN = 100000 + 5;

int ft[MaxN + 1];

int lowbit(int x) { return x & -x; }

void update(int pos, bool val)
{
	for (; pos <= MaxN; pos += lowbit(pos))
		ft[pos] ^= val;
}

void update(int l, int r, bool val)
{
	update(l, val);
	update(r + 1, ~val);
}

int query(int pos)
{
	int sum = 0;
	for (; pos > 0; pos -= lowbit(pos))
		sum ^= ft[pos];
	return sum;
}

int main()
{
	ios_base::sync_with_stdio(false);
	cin.tie(0);

	int t;
	scanf("%d", &t);
	for (int i = 1; i <= t; ++i)
	{
		char s[100002];
		scanf("%s", s);

		int q;
		scanf("%d", &q);

		printf("Case %d:\n", i);

		while (q--)
		{
			char op[2];
			scanf("%s", op);

			if (strcmp(op, "I") == 0)
			{
				int l, r;
				scanf("%d %d", &l, &r);
				update(l, r, 1);
			}
			else
			{
				int pos;
				scanf("%d", &pos);
				int ans = s[pos - 1] - '0';
				printf("%d\n", (ans + query(pos)) % 2);
			}
		}
		memset(ft, 0, sizeof(ft));
	}

	return 0;
}
