import numpy as np
from queue import PriorityQueue


def get_path(visited, end_node):
    path = []
    node = end_node

    while True:
        path.append(node)
        node = visited.get(node)

        if node == -1:
            break
    
    path.reverse()
    return path

def readMatrix(input):
    with open(input,'rt') as f:
        l=0
        matrix=[]
        for line in f:
            if l==0:
                tmp=line.split()
                start = int(tmp[0])
                end = int(tmp[1])
            else:
                matrix.append(line.split())
            l+=1
        
    matrix=np.array(matrix).astype(int)

    return matrix, start, end


def GBFS(matrix, start, end):
    path=[]
    visited={}
    pqueue = PriorityQueue()

    visited[start] = -1
    pqueue.put((0, start))

    while not pqueue.empty():
        u = pqueue.get()[1]

        if u == end:
            path = get_path(visited, end)
            break

        for v in np.where(matrix[u] != 0)[0]:
            if visited.get(v) == None:
                visited[v] = u
                pqueue.put((matrix[u, v], v))

    print(path)
    return visited, path

def UCS(matrix, start, end):
    path=[]
    dist = [1e9] * matrix.shape[0]
    visited={}
    pqueue = PriorityQueue()

    visited[start] = -1
    dist[start] = 0
    pqueue.put((0, start))

    while not pqueue.empty():
        w, u = pqueue.get() # w: trọng số, u: đỉnh

        if u == end:
            path = get_path(visited, end)
            break

        for v in np.where(matrix[u] != 0)[0]:
            if w + matrix[u, v] < dist[v]:
                visited[v] = u 
                dist[v] = w + matrix[u, v]
                pqueue.put((w + matrix[u, v], v))

    print(path)
    return visited, path

def Astar(matrix, start, end, pos):
    path=[]
    dist = [1e9] * matrix.shape[0]
    visited={}
    pqueue = PriorityQueue()

    visited[start] = -1 
    dist[start] = 0
    pqueue.put((0, 0, start)) # f, g, node

    while not pqueue.empty():
        f, g, u = pqueue.get()

        if u == end:
            path = get_path(visited, end)
            break

        for v in np.where(matrix[u] != 0)[0]:
            new_g = g + matrix[u, v]
            new_h = np.linalg.norm(pos[end] - pos[v])
            new_f = new_g + new_h

            if visited.get(v) == None or new_f < dist[v]:
                visited[v] = u
                dist[v] = new_f
                pqueue.put((new_f, new_g, v))

    print(path)
    return visited, path



matrix, start, end=readMatrix('diem_test.txt')
G, pos, color_map=initialize(matrix)
visited, path = Astar(matrix, start, end)