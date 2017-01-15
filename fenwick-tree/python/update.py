def init():
	ft = [0]*n

def query(pos):
	sum = 0
	while pos > 0:
		sum += ft[pos]
		pos -= (pos & -pos)
	return sum

def update(pos, val):
	while pos <= n:
		ft[pos] +=  val
		pos += (pos & -pos)
	return None