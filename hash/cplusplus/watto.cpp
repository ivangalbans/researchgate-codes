#include <bits/stdc++.h>
using namespace std;

#define endl '\n'

typedef long long ll;

const ll
		MOD = 1110111110111,
		N = 1000001,
		A = 11;
int n, m;
ll base[N];
set<ll> S;
string t;

ll get_hash(string s)
{
	ll ret = 0;
	for (int i = 0; i < (int)s.length(); ++i)
	{
		ret += s[i] * base[i];
		ret %= MOD;
	}
	return ret;
}

int main()
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);

	base[0] = 1;
	for (int i = 1; i < N; ++i)
		base[i] = (base[i - 1] * A) % MOD;

	cin >> n >> m;
	while (n--)
	{
		cin >> t;
		S.insert(get_hash(t));
	}
	while (m--)
	{
		bool ok = false;
		cin >> t;
		ll h = get_hash(t);
		for (int i = 0; i < (int)t.size(); ++i)
			for (int j = 'a'; j <= 'c'; ++j)
				if (j != t[i])
					ok |= S.count(((h + (j - t[i]) * base[i]) + 4 * MOD) % MOD);
		cout << (ok ? "YES" : "NO") << endl;
	}

	return 0;
}
