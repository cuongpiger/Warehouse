import networkx as nx
import numpy as np

G=nx.generators.community.connected_caveman_graph(3, 4)
print(G)
matrix=nx.adjacency_matrix(G)
matrix=np.array(matrix.todense(),dtype=int)
count=np.count_nonzero(matrix)
nums = np.random.randint(1,10, count)

matrix[np.where(matrix==1)]=nums
print(matrix)
np.savetxt('MST.txt', matrix, fmt='%d', delimiter=' ')