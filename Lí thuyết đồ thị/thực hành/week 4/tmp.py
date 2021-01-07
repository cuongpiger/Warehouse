import numpy as np
a = np.array([[1,2,3,4,5], [1,2,3,4,20], [1,2,2,4,5]])

indices = np.where(a > 3)

b = [(3, 2, 3), (1, 2, 3), (2, 1, 3)]

print(np.zeros(10, dtype=np.int))