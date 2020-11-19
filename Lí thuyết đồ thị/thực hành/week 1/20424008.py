from tkinter import Tk
from tkinter import filedialog
import numpy as np
import pandas as pd
import os


root = Tk()
root.withdraw()


class Task():
    def __init__(self, path):
        self.path = path # lưu path của file

    def __call__(self):
        self.ori_matrix = self.read_matrix_from_file()

        if type(self.ori_matrix) != type(None): # nếu đọc file thành công
            df = pd.DataFrame(self.ori_matrix)
            df.index = pd.RangeIndex(start=1, stop=self.ori_matrix.shape[0] + 1)
            df.columns = pd.RangeIndex(start=1, stop=self.ori_matrix.shape[0] + 1)

            print(self.path, end='\n')
            print(df)
            print('_____________________________________________________________')

            self.type = self.is_directional_graph()
            self.matrix = self.ori_matrix.copy()

            if self.type == False: # là đồ thị có hướng
                for i in range(self.ori_matrix.shape[0]):
                    for j in range(i, self.ori_matrix.shape[0]):
                        tmp = self.ori_matrix[i][j] if self.ori_matrix[i][j] != 0 else self.matrix[j][i]
                        self.matrix[j][i] = tmp
                        self.matrix[i][j] = tmp
            else:
                self.matrix = self.ori_matrix

            self.neighbors = self.neighbors_of_vertices()

            res2, res3 = self.show_up_task_2_3()
            res4to7 = self.show_up_task_4_to_7()

            print("1.", 1 - int(self.type))
            print("2.", res2)
            print("3.", res3)
            print("4.", res4to7['no_even'])
            print("5.", res4to7['no_odd'])
            print("6.", res4to7['no_pen'])
            print("7.", res4to7['no_iso'])
        else:
            print("Có lỗi, dữ liệu không đúng định dạng hoặc tệp này không tồn tại!")
    
    # hàm đọc một ma trận từ file txt
    def read_matrix_from_file(self):
        if os.path.exists(self.path):
            with open(self.path, 'r') as reader:
                try:
                    tmp = [[float(x) for x in row.split(' ')] for row in reader]
                    matrix = np.array(tmp)
                    
                    if len(matrix.shape) == 2 and matrix.shape[0] == matrix.shape[1]:
                        return matrix
                except:
                    pass
                
        return None

    # hàm dùng kiểm tra một ma trận có phải là một ma trận đối xứng hay ko
    def is_directional_graph(self):
        # nếu một ma trận bằng chính với ma trận chuyển vị của nó thì nó là một ma trận đối xứng
        return (self.ori_matrix == self.ori_matrix.T).all() 

    # hàm in ra danh sách đỉnh kề của các đỉnh
    def neighbors_of_vertices(self):
        no_vertices = self.matrix.shape[0] # lấy ra số lượng các đỉnh
        vertices = [[] for _ in range(no_vertices)]
        rows, cols = np.where(self.matrix != 0)
        
        for i in range(rows.size):
            vertices[rows[i]].append(cols[i])
        
        return [np.array(row) for row in vertices]

    def show_up_task_2_3(self):
        res2 = []
        res3 = []

        for arr in self.neighbors:
            res2.append(' '.join((arr + 1).astype(str).tolist()))
            res3.append(str(arr.size))

        return ' '.join(res2), ' '.join(res3)

    # hàm in ra số đỉnh bậc chẳn và bậc lẻ của ma trận:
    def show_up_task_4_to_7(self):
        no_vertices = len(self.neighbors) # lấy ra số lượng các đỉnh
        no_even, no_iso, no_pen = 0, 0, 0 # lần lượt là số đỉnh bậc chẳn, lẻ, cô lập, treo
        
        for i in range(no_vertices):
            no_even += (self.neighbors[i].size % 2 == 0)
            no_iso += (self.neighbors[i].size == 0)
            no_pen += (self.neighbors[i].size == 1)
            
        return {
            'no_even': no_even,
            'no_odd': len(self.neighbors) - no_even,
            'no_iso': no_iso,
            'no_pen': no_pen
        }


if __name__ == "__main__":
    print('Tệp được chọn: ', end='')
    filename = filedialog.askopenfilename(filetypes=(("text files", "*.txt"), ("all files", "*.*")))
    
    tsk = Task(filename)
    tsk()
