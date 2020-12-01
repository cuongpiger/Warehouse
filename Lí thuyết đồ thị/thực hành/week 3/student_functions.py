import numpy as np


def DFS(matrix, start, end):
    visited = {}
    visited[start] = -1 # đánh dấu đỉnh `start` đã ghé thăm rồi
    path = [-1] * matrix.size # lưu vết
    stack = [start] # queue với phần tử đầu là đỉnh bắt đầu

    while stack:
        last_node = stack.pop() # lấy ra phần tử cuối cùng của queue

        if last_node == end:
            path = backtrace(path, start, end)
            break

        for neighbor in np.where(matrix[last_node] != 0)[0]:
            #if visited.get(neighbor) == None:
            visited[neighbor] = last_node # đánh dấu thăm rồi
            path[neighbor] = last_node # lưu vết
            stack.append(neighbor) # bỏ vô stack
    
    return visited, path

def BFS(matrix, start, end):
    visited = {}
    visited[start] = -1 # đánh dấu đỉnh `start` đã ghé thăm rồi
    path = [-1] * matrix.size # lưu vết
    queue = [start] # queue với phần tử đầu là đỉnh bắt đầu

    while queue:
        front_node = queue.pop(0) # lấy ra phần tử đầu tiên của queue

        if front_node == end:
            path = backtrace(path, start, end)
            break

        for neighbor in np.where(matrix[front_node] != 0)[0]:
            if visited.get(neighbor) == None:
                visited[neighbor] = front_node # đánh dấu thăm rồi
                path[neighbor] = front_node # lưu vết
                queue.append(neighbor) # bỏ vô queue
    
    return visited, path


def UCS(matrix, start, end, pos):
    path=[]
    visited={}
    return visited, path

def backtrace(parent, start, end):
    path = [end]
    while path[-1] != start:
        path.append(parent[path[-1]])
    path.reverse()
    return path


'''Prim algorithm from here to down'''
import queue
INF = 1e9

class Node:
    def __init__(self, id, dist):
        self.id = id
        self.dist = dist

    def __lt__(self, other):
        return self.dist <= other.dist


def printMST(n, path, dist, visited):
    ans = 0

    for i in range(n):
        if path[i] == -1:
            continue
    
        ans += dist[i]

        print('{} - {}: {}'.format(path[i], i, dist[i]))

    print('Weight of MST: {}'.format(ans))
    print('Visits: {}'.format(visited))


def Prim(matrix):
    n = matrix.shape[0]

    dist = [INF] * n
    path = [-1] * n
    mark = [False] * n
    visited = {}

    pq = queue.PriorityQueue()
    pq.put(Node(0, 0))
    dist[0] = 0
    visited[0] = -1

    while not pq.empty():
        top = pq.get()
        u = top.id
        mark[u] = True

        for neighbor in np.where(matrix[top.id] != 0)[0]:
            w = matrix[top.id][neighbor]

            if mark[neighbor] == False and w < dist[neighbor]:
                dist[neighbor] = w
                pq.put(Node(neighbor, w))
                path[neighbor] = u
                visited[neighbor] = u

    printMST(n, path, dist, visited)

    return visited, []