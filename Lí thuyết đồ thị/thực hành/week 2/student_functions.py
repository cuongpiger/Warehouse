import numpy as np


def DFS(matrix, start, end):
    """
    BFS algorithm:
    Parameters:
    ---------------------------
    matrix: np array 
        The graph's adjacency matrix
    start: integer 
        start node
    end: integer
        ending node
    
    Returns
    ---------------------
    visited
        The dictionary contains visited nodes, each key is a visited node,
        each value is the adjacent node visited before it.
    path: list
        Founded path
    """
    # TODO: 

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
    """
    DFS algorithm
     Parameters:
    ---------------------------
    matrix: np array 
        The graph's adjacency matrix
    start: integer 
        start node
    end: integer
        ending node
    
    Returns
    ---------------------
    visited 
        The dictionary contains visited nodes: each key is a visited node, 
        each value is the key's adjacent node which is visited before key.
    path: list
        Founded path
    """

    # TODO: 

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
    """
    Uniform Cost Search algorithm
     Parameters:
    ---------------------------
    matrix: np array 
        The graph's adjacency matrix
    start: integer 
        start node
    end: integer
        ending node
    pos: dictionary. keys are nodes, values are positions
        positions of graph nodes
    Returns
    ---------------------
    visited
        The dictionary contains visited nodes: each key is a visited node, 
        each value is the key's adjacent node which is visited before key.
    path: list
        Founded path
    """
    # TODO: 
    path=[]
    visited={}
    return visited, path

def backtrace(parent, start, end):
    path = [end]
    while path[-1] != start:
        path.append(parent[path[-1]])
    path.reverse()
    return path
