import itertools

# hàm phát sinh ra mọi tập con ko rỗng bậc `n` của tập `s`
def findSubsets(s, n):
    return list(map(list, itertools.combinations(s, n)))

# đọc từng dòng từ f trả về một mảng các frequent item
def returnDataset(file):
    T = []
    
    f = open(file, 'r')
    trans = f.readline().strip().split(' ')
    T.append(trans)
    
    while trans != ['']:
        trans = f.readline().strip().split(' ')
        T.append(trans)
        
    return T

# hàm lấy ra tập ko giao giữa 2 tập
def non_intersecting(s, s_sub):
    return list(set(s) - set(s_sub))

# kiểm tra một tập `s_sub` có phải là tập con của tập `s` ko
def isSubset(s, s_sub):
    return set(s_sub).issubset(set(s))

# đếm số lần xuất hiện của tập `s` trong CSDL `T`
def confCount(T, s):
    cnt = 0
    
    for t in T:
        if isSubset(t, s):
            cnt += 1
            
    return cnt

# hàm khởi tạo tập ứng viên H_{m + 1}
def candidateGen(Hm, m1):
    Hm1 = []
    
    for i in range(len(Hm) - 1):
        for j in range(i + 1, len(Hm)):
            f1, f2 = list(Hm[i]), list(Hm[j])
            
            if f1[:-1] == f2[:-1]:
                h = f1 + [Hm[j][-1]]
                h_subs = findSubsets(h, m1 - 1)
                
                flag = True
                for sub in h_subs:
                    if sub not in Hm:
                        flag = False
                        break
                        
                if flag:
                    Hm1.append(h)
    
    return list(set(tuple(i) for i in Hm1))

def apGenRules(f, Hm, k, m, T, minconf, H, res):
    if k > m + 1 and Hm != []:
        Hm1 = candidateGen(list(map(lambda x: list(x), Hm)), m + 1)
        f_cnt = confCount(T, f)
        
        for hm1 in Hm1:
            s_fk = non_intersecting(f, hm1)
            fk_cnt = confCount(T, s_fk)
            conf = f_cnt/fk_cnt*100.0
            
            r = {}
            r['x'] = s_fk
            r['y'] = hm1
            r['xy_cnt'] = f_cnt
            r['x_cnt'] = fk_cnt
            r['conf'] = conf
            res.append(r)
                
            # if conf < minconf:
            #     Hm1.remove(hm1)
        
        H.append(Hm1)
        apGenRules(f, Hm1, k, m + 1, T, minconf, H, res)

def printResults(H, res):
    for i in range(len(H)):
        print('H{0}: {1}'.format(i + 1, H[i]))
        print('-'*30)
        
    print('='*30)
    
    for i in range(len(res)):
        print('Rule{0}: {1} => {2} | {3}/{4} | conf = {5}'.format(i + 1, res[i]['x'], res[i]['y'], res[i]['xy_cnt'], res[i]['x_cnt'], res[i]['conf']))
        print('-'*30)

    print('*'*30)

def genRules(T, F, minconf): # F là tập các frequent itemsets
    for f in F:
        H1 = []
        H = []
        res = []

        if len(f) > 1:
            f1_subs = findSubsets(f, 1)
            
            for y in f1_subs:
                r = {}
                x = non_intersecting(f, y)
                
                xy_cnt = confCount(T, x + y)
                x_cnt = confCount(T, x)
                conf = xy_cnt/x_cnt*100.0
                
                if conf >= minconf:
                    H1.append(y)
                    r['x'] = x
                    r['y'] = y
                    r['xy_cnt'] = xy_cnt
                    r['x_cnt'] = x_cnt
                    r['conf'] = conf
                    res.append(r)
                
        H1 = list(set(tuple(i) for i in H1))
        H.append(H1)
        apGenRules(f, H1, len(f), 1, T, minconf, H, res)
        printResults(H, res)

T = returnDataset('data.txt')
# F = [['Bread', 'Cheese'], 
#      ['Bread', 'Juice'], 
#      ['Bread', 'Milk'], 
#      ['Cheese', 'Juice'], 
#      ['Juice', 'Milk']]

F = [['Bread', 'Cheese', 'Juice']]

genRules(T, F, 60.0)
