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

matrix, start, end=readMatrix('diem_test.txt')
visited, path  = GBFS(matrix, start, end)