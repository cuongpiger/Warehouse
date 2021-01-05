import networkx as nx
import numpy as np
import matplotlib.pyplot as plt


def readMatrix(input=r'Lab04-Coloring/MST (2).txt', l=1):
    start=None
    end=None
    with open(input,'rt') as f:
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


def createMaskMatrix(matrix):
    m = matrix.copy()
    np.fill_diagonal(m, 0) # xóa các cạnh khuyên

    m[m != 0] = 1 # nếu có cạnh nối giữa hai đỉnh, thay trọng số của cạnh này thành 1
    m = np.bitwise_or(m, m.T)

    return m


def createListEdgesFromMatrix(matrix):
    edges = []
    m = createMaskMatrix(matrix)
    i, j = np.where(m == 1)

    return [(x, y) for x, y in zip(i, j)]
    


def drawGraph(edges, colors_map):
    graph = nx.DiGraph()
    graph.add_edges_from([(str(u), str(v)) for u, v in edges])

    pos = nx.spring_layout(graph)
    node_colors = {}
    for key, color in zip(colors_map.keys(), np.linspace(0, 1, len(colors_map.keys()))):
        for node in colors_map[key]:
            node_colors[str(node)] = color
    color_values = [node_colors[node] for node in graph.nodes()]

    nx.draw_networkx_nodes(graph, pos, cmap=plt.get_cmap('jet'), node_color=color_values, node_size=700)
    nx.draw_networkx_labels(graph, pos)
    nx.draw_networkx_edges(graph, pos, edgelist=graph.edges(), arrows=False)

    plt.show()



class WelshPowell:
    def __init__(self, matrix):
        self.matrix = createMaskMatrix(matrix)
    
    """
    DESCRIPTION:
        - Hàm tính toán bậc của các node và sắp xếp giảm dần theo bậc.
    PARAMETERS:
        [(bậc, đỉnh), (bâc, đỉnh),...]
    """
    def calculateDegrees(self):
        return sorted([(sum(line), i) for i, line in enumerate(self.matrix)], reverse=True)

    def coloring(self):
        n = self.matrix.shape[0] # số lượng node
        degrees = self.calculateDegrees()
        color = 0 # index màu hiện tại
        colored = [-1]*n 
        color_map = {}
        mark = [False]*n # đánh dấu các node đã dc tô màu

        while sum(mark) != n:
            _, node = degrees.pop(0)
            
            if not mark[node]:
                mark[node] = True
                colored[node] = color # đánh dấu index màu dc tô tại node này
                color_map[color] = [node]
                strangers = [v for v in np.where(self.matrix[node] == 0)[0] if v != node and not mark[v]] # lấy ra các node ko kề vs `node` và chưa dc tô màu

                for stranger in strangers:
                    flag = len([True for v in np.where(self.matrix[stranger] == 1)[0] if colored[v] == colored[node]]) # kiểm tra trong n~ node kề với `stranger` xem có tồn tại node nào đã dc tô cùng màu vs node `node` hay chưa

                    if flag == 0: # nếu `stranger` thỏa
                        mark[stranger] = True # đánh dấu node này đã dc tô
                        colored[stranger] = color # tô node này bằng giá trị của `color`
                        color_map[color].append(stranger)

                color += 1

        return color_map








