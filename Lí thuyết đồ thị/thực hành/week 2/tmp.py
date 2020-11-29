import numpy as np

def backtrace(parent, start, end):
    path = [end]
    while path[-1] != start:
        path.append(parent[path[-1]])
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

def DFS(matrix, start, end):
    visited = {}
    visited[start] = -1 # đánh dấu đỉnh `start` đã ghé thăm rồi
    path = [-1] * matrix[0].size # lưu vết
    stack = [start] # queue với phần tử đầu là đỉnh bắt đầu

    while stack:
        last_node = stack.pop() # lấy ra phần tử cuối cùng của queue

        if last_node == end:
            path = backtrace(path, start, end)
            break

        for neighbor in np.where(matrix[last_node] != 0)[0]:
            if visited.get(neighbor) == None:
                visited[neighbor] = last_node # đánh dấu thăm rồi
                path[neighbor] = last_node # lưu vết
                stack.append(neighbor) # bỏ vô stack
    
    return visited, path


matrix, start, end = readMatrix('input.txt')


visited, path = DFS(matrix, start, end)

print(path)