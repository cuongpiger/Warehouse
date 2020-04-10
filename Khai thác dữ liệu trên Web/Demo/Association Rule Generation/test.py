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

def apGenRules(f, Hm, k, m, T, minconf, res):
    if k > m + 1 and Hm != []:
        rules = []
        Hm1 = candidateGen(list(map(lambda x: list(x), Hm)), m + 1)
        f_cnt = confCount(T, f)
        
        for hm1 in Hm1:
            s_fk = non_intersecting(f, hm1)
            fk_cnt = confCount(T, s_fk)
            conf = f_cnt/fk_cnt*100.0

            # ở đây sẽ có 2 option, vì trường muốn xuất ra đầy đủ kết quả
            # kết cả hợp lệ và ko hợp lệ

            # option 1: xuất cả hợp lệ và ko hợp lệ
            r = {}
            r['x'] = s_fk
            r['y'] = hm1
            r['xy_cnt'] = f_cnt
            r['x_cnt'] = fk_cnt
            r['conf'] = conf
            rules.append(r)

            # # option 2: chỉ xuất kết quả hợp lệ, đồng thời optimize vùng nhớ
            # # và tốc độ thư thi trong code
            # if conf >= minconf:
            #     r = {}
            #     r['x'] = s_fk
            #     r['y'] = hm1
            #     r['xy_cnt'] = f_cnt
            #     r['x_cnt'] = fk_cnt
            #     r['conf'] = conf
            #     rules.append(r)
            # else:
            #     Hm1.remove(hm1)
        
        res.append([Hm1, rules, f])
        apGenRules(f, Hm1, k, m + 1, T, minconf, res)

def printResults(res):
    noRule = 1
    print('F = {0}'.format(res[0][2]))
    print('='*20)

    for i in range(len(res)):
        print('H{0}: {1}'.format(i + 1, res[i][0]))
        print('-'*20)

        for rule in res[i][1]:
            print('Rule{0}: {1} => {2} | conf = {3}/{4} = {5}'.format(noRule, rule['x'], rule['y'], rule['xy_cnt'], rule['x_cnt'], rule['conf']))
            print('.'*20)
            noRule += 1

        print('_'*20)

    print('*'*20)

def genRules(T, F, minconf): # F là tập các frequent itemsets
    for f in F:
        H1 = []
        rules1 = []
        res = []

        if len(f) > 1:
            f1_subs = findSubsets(f, 1)
            
            for y in f1_subs:
                r = {}
                x = non_intersecting(f, y)
                
                xy_cnt = confCount(T, x + y)
                x_cnt = confCount(T, x)
                conf = xy_cnt/x_cnt*100.0

                # ở đây sẽ có 2 option, vì trường muốn xuất ra đầy đủ kết quả
                # kết cả hợp lệ và ko hợp lệ

                # option 1: xuất cả hợp lệ và ko hợp lệ
                r['x'] = x
                r['y'] = y
                r['xy_cnt'] = xy_cnt
                r['x_cnt'] = x_cnt
                r['conf'] = conf
                rules1.append(r)
                H1.append(y)

                # # option 2: chỉ xuất kết quả hợp lệ, đồng thời optimize vùng nhớ
                # # và tốc độ thư thi trong code
                # if conf >= minconf:
                #     r['x'] = x
                #     r['y'] = y
                #     r['xy_cnt'] = xy_cnt
                #     r['x_cnt'] = x_cnt
                #     r['conf'] = conf
                #     rules1.append(r)
                #     H1.append(y)
                
        H1 = list(set(tuple(i) for i in H1))
        res.append([H1, rules1, f])
        apGenRules(f, H1, len(f), 1, T, minconf, res)
        printResults(res)

# main
T = returnDataset('data.txt')
# F = [['Apple', 'Bread'], 
#      ['Apple', 'Pie'], 
#      ['Bread', 'Cheese'], 
#      ['Bread', 'Crab'], 
#      ['Bread', 'Milk'],
#      ['Bread', 'Pie'], 
#      ['Cheese', 'Milk']]

F = [['Apple', 'Bread', 'Pie'],
     ['Bread', 'Cheese', 'Milk']]

genRules(T, F, 80.0)
