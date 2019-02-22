#include <bits/stdc++.h>
using namespace std;

#define endl '\n'
#define MAXN 2005
#define DB(x) cout << #x << " = " << x << endl;

typedef long long ll;

const ll mod = 1e9 + 9;
const ll x = 3, y = 5;

string t[MAXN];
string p[MAXN];
int nt, mt, np, mp;

ll ht[MAXN][MAXN];
ll prime[2][MAXN];

ll mmod(ll a, ll b)
{
	return (a * b) % mod;
}

void compute_hash()
{
	for (int i = 1; i <= nt; ++i)
		for (int j = 1; j <= mt; ++j)
			ht[i][j] = (((mmod(t[i - 1][j - 1], mmod(prime[0][i], prime[1][j])) + ht[i - 1][j] + ht[i][j - 1]) % mod) - ht[i - 1][j - 1] + mod) % mod;
}

ll patron_hash()
{
	ll hp = 0;
	for (int i = 1; i <= np; ++i)
		for (int j = 1; j <= mp; ++j)
			hp = (hp + p[i - 1][j - 1] * mmod(prime[0][i], prime[1][j])) % mod;
	return hp;
}

ll accumulate(int f, int c)
{
	return ((ht[f][c] - ht[f - np][c] - ht[f][c - mp] +
					 ht[f - np][c - mp]) +
					3 * mod) %
				 mod;
}

int solve(ll hp)
{
	int match = 0;
	for (int i = np; i <= nt; ++i)
		for (int j = mp; j <= mt; ++j)
			if (accumulate(i, j) == mmod(hp, mmod(prime[0][i - np], prime[1][j - mp])))
				++match;
	return match;
}

int main()
{

	prime[0][0] = 1;
	prime[1][0] = 1;
	for (int i = 1; i < MAXN; ++i)
	{
		prime[0][i] = (prime[0][i - 1] * x) % mod;
		prime[1][i] = (prime[1][i - 1] * y) % mod;
	}

	cin >> np >> mp;
	cin >> nt >> mt;

	for (int i = 0; i < np; ++i)
		cin >> p[i];
	for (int i = 0; i < nt; ++i)
		cin >> t[i];

	compute_hash();
	ll hp = patron_hash();

	cout << solve(hp) << endl;

	return 0;
}
