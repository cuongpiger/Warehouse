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
    graph = nx.DiGraph(directed=False)
    graph.add_edges_from([(str(u), str(v)) for u, v in edges])

    pos = nx.spring_layout(graph)
    node_colors = {}
    for key, color in zip(colors_map.keys(), np.linspace(0, 1, len(colors_map.keys()))):
        for node in colors_map[key]:
            node_colors[str(node)] = color
    color_values = [node_colors[node] for node in graph.nodes()]

    # nx.draw_networkx_nodes(graph, pos, cmap=plt.get_cmap('jet'), node_color=color_values, node_size=700)
    # nx.draw_networkx_labels(graph, pos)
    # nx.draw_networkx_edges(graph, pos, edgelist=graph.edges(), arrows=False)
    nx.draw_networkx(graph, arrows=False, node_color=color_values, node_size=700, width=2)

    plt.show()


class VertexColoring:
    def __init__(self, matrix):
        self.matrix = createMaskMatrix(matrix)
    

    """
    DESCRIPTION:
        - Hàm tính toán bậc của các node và sắp xếp giảm dần theo bậc.
    PARAMETERS:
        [(bậc, đỉnh), (bâc, đỉnh),...]
    """
    def calculateDegrees(self, matrix):
        return sorted([(sum(line), i) for i, line in enumerate(matrix)], reverse=True)


    def welshPowell(self):
        n = self.matrix.shape[0] # số lượng node
        degrees = self.calculateDegrees(self.matrix)
        color = 0 # index màu hiện tại
        colored = [-1]*n 
        color_map = {}

        while degrees != []:
            _, node = degrees.pop(0)
            
            if colored[node] == -1:
                colored[node] = color # đánh dấu index màu dc tô tại node này
                color_map[color] = [node]
                strangers = [v for v in np.where(self.matrix[node] == 0)[0] if v != node and colored[v] == -1] # lấy ra các node ko kề vs `node` và chưa dc tô màu

                for stranger in strangers:
                    flag = len([True for v in np.where(self.matrix[stranger] == 1)[0] if colored[v] == colored[node]]) # kiểm tra trong n~ node kề với `stranger` xem có tồn tại node nào đã dc tô cùng màu vs node `node` hay chưa

                    if flag == 0: # nếu `stranger` thỏa
                        colored[stranger] = color # tô node này bằng giá trị của `color`
                        color_map[color].append(stranger)

                color += 1

        return color_map


    def heuristic2(self):
        n = self.matrix.shape[0]
        m = self.matrix.copy()
        colored = np.zeros((n, n), dtype=int) # index dòng là màu, cột là node
        color_map = {}
        node = self.calculateDegrees(m)[0][1]
        mark = [False]*n
        
        while sum(mark) != n:
            color = 0
            mark[node] = True # đánh dấu `node` đã dc tô màu rồi

            ''' tô màu thấp nhất cho `node` '''
            for c in range(n):
                if colored[c, node] == 0:
                    colored[c, node] = 1
                    color = c
                    color_map[color] = True

                    break
            
            edges = np.where(m[node] == 1) # lấy ra các node kề với `node`
            m[node, edges] = 0 # hạ bậc `node` thành 0
            m[edges, node] = 0 # xóa tất cả các cạnh nối với `node`
            colored[color, edges] = -1 # cấm tất cả các node kề vs `node` tô màu `color`

            ''' lấy `node` mới '''
            for _, v in self.calculateDegrees(m):
                if not mark[v]:
                    node = v
                    break

        for c in color_map.keys():
            color_map[c] = np.where(colored[c] == 1)[0]

        return color_map