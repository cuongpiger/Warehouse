import numpy as np
from queue import PriorityQueue as PQ


INF = 1e9


def DFS(matrix, start, end):
    pass


def BFS(matrix, start, end):
    pass


def UCS(matrix, start, end, pos):
    pass


def preprocess_matrix(ori_matrix):
    matrix = ori_matrix.copy()
    
    for i in range(matrix.shape[0]):
        matrix[i, :] = matrix[:, i]

    return matrix


def create_graph(matrix):
    graph = []
    indices = np.where(matrix != 0)

    for i, j in zip(indices[0], indices[1]):
        graph.append((matrix[i, j], i, j)) # weight, u, v

    return np.array(sorted(graph))


def find_parent(parent, i):
    if parent[i] == i:
        return i

    return find_parent(parent, parent[i])


def apply_union(parent, rank, x, y):
    xroot, yroot = find_parent(parent, x), find_parent(parent, y)

    if rank[xroot] < rank[yroot]:
        parent[xroot] = yroot
    elif rank[xroot] > rank[yroot]:
        parent[yroot] = xroot
    else:
        parent[yroot] = xroot
        rank[xroot] += 1


def return_edges(path):
    res = []

    for i, v in enumerate(path):
        if v != -1:
            res.append((v, i))

    return res


def Prim(matrix):
    np.random.seed(0)

    n = matrix.shape[0] # get the number of vertices
    new_matrix = preprocess_matrix(matrix) # matrix pre-processing
    start = np.random.randint(n) # get vertex to start
    
    dist = [INF] * n
    path = [-1] * n
    visited = [False] * n

    pq = PQ()
    pq.put((0, start)) # (weight, vertex)
    dist[start] = 0

    while not pq.empty():
        top = pq.get()
        u = top[1] # get vertex's id
        visited[u] = True

        for v in np.where(new_matrix[u] != 0)[0]:
            w = new_matrix[u][v]

            if not visited[v] and w < dist[v]:
                dist[v] = w
                pq.put((w, v)) # (weight, vertex)
                path[v] = u
   
    return return_edges(path)


def Kruskal(matrix):
    n, i, e = matrix.shape[0], 0, 0
    new_matrix = preprocess_matrix(matrix)
    graph = create_graph(new_matrix)
    parent = np.arange(n)
    rank = np.zeros(n, dtype=np.int)
    path = []

    while e < n - 1:
        w, u, v = graph[i]
        i += 1
        x, y = find_parent(parent, u), find_parent(parent, v)

        if x != y:
            e += 1
            path.append((u, v))
            apply_union(parent, rank, x, y)
    
    return path
