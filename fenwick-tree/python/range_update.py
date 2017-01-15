range_update(l, r, val):
	update(l, val)
	update(r+1, -val)
	return None