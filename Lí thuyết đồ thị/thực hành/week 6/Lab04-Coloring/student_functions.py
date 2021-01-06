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
   
   
    path=[]
    visited={}
    
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
    
    path=[]
    visited={}
   
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
def Prim(matrix):
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
    edges: list
        List of founded edges in spanning tree (sort by search order)
        example: [[1,2],[3,4],[4,5]]
    """
    # TODO: 
    edges=[]
    n_v=matrix.shape[0]
    np.random.seed(0)
    start_v=np.random.randint(0,n_v-1)
    
    return edges

def Kruskal(matrix):
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
   edges: list
        List of founded edges in spanning tree (sort by search order)
        example: [(1,2),(3,4),(4,5)]
    """ 
    # TODO: 
    edges=[]
    return edges


def createMaskMatrix(matrix):
    m = matrix.copy()
    np.fill_diagonal(m, 0) # xóa các cạnh khuyên

    m[m != 0] = 1 # nếu có cạnh nối giữa hai đỉnh, thay trọng số của cạnh này thành 1
    m = np.bitwise_or(m, m.T)

    return m


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


def coloring(matrix):
    """
    return color_map:
        * color_map: dictionary (key: color-index, value: [list of nodes painted with color])
    """
    m = VertexColoring(matrix)
    return m.heuristic2()

    