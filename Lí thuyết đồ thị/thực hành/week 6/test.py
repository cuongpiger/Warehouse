from module import *

matrix, start, end = readMatrix()
edges = createListEdgesFromMatrix(matrix)

m = VertexColoring(matrix)
color_map = m.heuristic2()

print(color_map)