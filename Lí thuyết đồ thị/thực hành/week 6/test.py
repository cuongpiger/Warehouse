""" 
🔖 BÀI 1
  - Giả sử có 9 cuộc mít-tinh: A, B, C, D, E, F, G, H, I dc tổ chức. Các cuộc mít-tinh:
AE, BC, CD, ED, ABD, AHI, BHI, DFI, DHI, FGH ko dc tổ  chức đồng thời. 
  👉 Hãy sử dụng thuật toán tô màu tối ưu để bố trí các cuộc mít-tinh vào ít buổi nhất.

🔖 BÀI 2
  - Một giao lộ gồm 13 tuyến đường: AB, AC, AD, BA, BC, BD, DA, DB, DC, EA, EB, EC,
ED.
    - Các tuyến giao nhau: EC, AD, DA / EB, AC, AD, DA / AC, EB, BD, DB
    - Các tuyến ngược nhau: AB, BC / ED, DC / EA, AB
    - BA, DC, ED ko giao vs các tuyến khác.
    - Các tuyến cùng đỉnh xuất phát hoặc cùng đích thì ko giao nhau: ED, EA / BC, BA
/ BC, DC / BA, EA 
    - Song song thì ko giao nhau.
  👉 Tìm số đèn giao thông tối thiểu cần đặt.
"""


from module import *
import numpy as np

""" --------------------------------------------------------------------- BÀI 1 """
""" matrix1 = np.array([
    (0, 1, 0, 1, 1, 0, 0, 1, 1),
    (1, 0, 1, 1, 0, 0, 0, 1, 1),
    (0, 1, 0, 1, 0, 0, 0, 0, 0),
    (1, 1, 1, 0, 1, 1, 0, 1, 1),
    (1, 0, 0, 1, 0, 0, 0, 0, 0),
    (0, 0, 0, 1, 0, 0, 1, 1, 1),
    (0, 0, 0, 0, 0, 1, 0, 1, 0),
    (1, 1, 0, 1, 0, 1, 1, 0, 1),
    (1, 1, 0, 1, 0, 1, 0, 1, 0)
])


m = VertexColoring(matrix1)
color_map = m.heuristic2()

print(color_map) """

matrix2 = np.array([
  (0, 0, 0,	0, 1,	0, 0,	0, 0,	1, 0,	0, 0),
  (0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0),
  (0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0),
  (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
  (1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
  (0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0),
  (0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0),
  (0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0),
  (0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1),
  (1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
  (0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0),
  (0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  (0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0)
])

m = VertexColoring(matrix2)
color_map = m.heuristic2()

print(color_map)
