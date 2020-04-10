import itertools
import operator
from math import fabs

# hàm đọc dữ liệu từ file txt
def readData(file): # filename
    MS = {} # chứa các cặp item-MIS, với key là item và value là mis
    T = [] # dataset đọc được từ `file`
    
    f = open(file, 'r')
    noTrans = int(f.readline().strip())
    
    for _ in range(noTrans):
        trans = f.readline().strip().split(' ') # trả về 1 mảng chứa các item của 1 transaction
        T.append(trans) # thêm transaction này vào dataset `T`
    
    # đọc từng cặp item - MIS trong `file`
    itemMis = f.readline().strip()
    while itemMis != '':
        item, mis = itemMis.split(' ')
        MS[item] = float(mis) # bỏ vào trong `MS`
        itemMis = f.readline().strip() # đọc dòng tiếp theo trong `file`
        
    # sắp xếp tăng dần dựa vào value cho mảng 
    MS = dict(sorted(MS.items(), key=operator.itemgetter(1)))
    f.close()
    
    return (T, MS)

# hàm đếm hỗ trợ cho từng item trong dataset
def countSupItems(T): # T là dataset
    supItems = {} # dict chứa các giá trị support count của mỗi item với 
                  # key là item và value là support count
    
    for trans in T: # duyệt qua từng transaction trong dataset `T`
        for item in trans: # duyệt qua từng item trong một transaction
            if item in supItems: # nếu đã tồn tại item này trong `supItems`
                supItems[item] += 1
            else:
                supItems[item] = 1
                
    return supItems

# step 2 trong hàm `genL1`
def genLstep2(M, supItems, n): # M là dict các key-value là item-MIS, 
                                # supItems là từ hàm `countSupItems`, n là số trans trong dataset
    L = [] # mảng các item thỏa giá trị MIS
    iKey = ''
    
    # tìm item có supcount/n > mis của chính nó (tạm gọi supcount/n là supmis)
    for key in M.keys():
        if supItems[key]/n*100.0 >= M[key]:
            L.append(key)
            iKey = key
            break
            
    if iKey != '':
        keys = list(M.keys())
        iKeyIndex = keys.index(iKey)
        
        for i in range(iKeyIndex + 1, len(keys)):
            if supItems[keys[i]]/n*100.0 >= M[iKey]:
                L.append(keys[i])
                
    return L

# tạo ra F1
def genF1(L, M, supItems, n):
    F1 = []
    
    for l in L:
        if supItems[l]/n*100.0 >= M[l]:
            F1.append(l)
            
    return F1

def level2candidateGen(L, M, supItems, n, phi):
    C2 = []
    
    for i in range(len(L) - 1):
        if supItems[L[i]]/n*100.0 >= M[L[i]]:
            for j in range(i + 1, len(L)):
                if supItems[L[j]]/n*100 >= M[L[j]] and fabs(supItems[L[j]] - supItems[L[i]])/n*100.0 <= phi:
                    C2.append([L[i], L[j]])
                    
    return C2

# tạo ra dict lưu vị trí index của các item trong `L`
def createItemPos(L):
    itemPos = {}
    
    for i in range(len(L)):
        itemPos[L[i]] = i
        
    return itemPos

def findSubsets(s, n):
    return list(map(list, itertools.combinations(s, n)))

def msCandidateGen(M, Fkminus1, itemPos, supItems, n, k, phi):
    Ck = []
    
    for i in range(len(Fkminus1) - 1):
        for j in range(i + 1, len(Fkminus1)):
            f1, f2 = Fkminus1[i], Fkminus1[j]
            
            if f1[:-1] == f2[:-1] and itemPos[f1[-1]] < itemPos[f2[-1]] and fabs(supItems[f1[-1]] - supItems[f2[-1]])/n*100.0 <= phi:
                c = f1 + [f2[-1]]
                c_subs = findSubsets(c, k - 1)
                
                flag = True
                for sub in c_subs:
                    if (c[0] in sub or M[c[1]] == M[c[0]]) and (sub not in Fkminus1):
                        flag = False
                        break
                        
                if flag:
                    Ck.append(c)
                    
    return Ck

# tạo ra L1
def msApriori(M, T, phi): # M là dict các key-value là item-MIS, T là dataset
    C, F = [-1], [-1]
    k = 2
    
    # step 1: đếm trợ cho từng item trong dataset `T`
    supItems = countSupItems(T)
    
    # step 2: tạo ra list các item `L`
    L = genLstep2(M, supItems, len(T))
    itemPos = createItemPos(L)
    
    # tạo ra F1
    F1 = genF1(L, M, supItems, len(T))
    
    C.append(L)
    F.append(F1)
    
    while not F[k - 1]:
        if k == 2:
            C2 = level2candidateGen(L, M, supItems, len(T), phi)
            C.append(C2)
        else:
            Ck = msCandidateGen(M, F[k - 1], itemPos, supItems, len(T), k, phi)
            print(Ck)
    

def solve(file, phi):
    T, M = readData(file)
    msApriori(M, T, phi)

solve('data.txt', 100.0)