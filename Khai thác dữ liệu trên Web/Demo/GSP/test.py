from functools import reduce
import operator
import itertools

def readData(file):
    S = []
    n = 0
    
    f = open(file, 'r')
    seq = f.readline().strip()
    
    while seq != '':
        n += 1
        pats = seq.split(',')
        line = []
        
        for p in pats:
            pat = p.split(' ')
            line.append(pat)
            
        S.append(line)
        seq = f.readline().strip()
        
    return (S, n)

def initPass(S):
    res = dict()
    
    for seq in S:
        items = reduce(lambda a, b: set(a).union(set(b)), seq)
        
        for item in items:
            res[item] = res.get(item, 0) + 1
          
    res = dict(sorted(res.items(), key=operator.itemgetter(0)))
    return res

def genF1(supItems, n, minsup):
    F1 = []
    
    for key, val in supItems.items():
        if val/n*100.0 >= minsup:
            F1.append([])
            F1[-1].append(tuple([key]))
            
    return F1

def compare2seq(seq1, seq2):
    s1 = list(map(lambda x: list(x), seq1))
    s2 = list(map(lambda x: list(x), seq2))
    tmp1 = list(map(lambda x: list(x), seq1))
    tmp2 = list(map(lambda x: list(x), seq2))

    res = []
    
    del tmp1[0][0]
    del tmp2[-1][-1]
    
    if not tmp1[0]:
        tmp1.pop(0)
        
    if not tmp2[-1]:
        tmp2.pop()
        
    if tmp1 == tmp2:
        tmp = list(map(lambda x: list(x), seq1))

        if len(s2[-1]) == 1:
            s1.append(s2[-1])
        else:
            s1[-1].append(s2[-1][-1])

        res = s1
    
    return res

def findSubsets(s, n): 
    return list(map(list, itertools.combinations(s, n)))

def findSubseqs(c):
    subseqs = []
    
    for i in range(len(c)):
        subsets = findSubsets(c[i], len(c[i]) - 1)
        head = c[:i]
        tail = c[i + 1:]
        
        for sub in subsets:
            tmp = head + [sub] + tail
            tmp = [x for x in tmp if x]
            tmp = [tuple(x) for x in tmp]
            subseqs.append(tmp)
            
    return subseqs

def candidateK2(F1):
    C2 = list()
    
    # [tuple([1, 2]), tuple([4])]
    for i in range(len(F1) - 1):
        for j in range(i + 1, len(F1)):
            s1, s2 = F1[i][0][0], F1[j][0][0]
            
            c1 = [tuple([s1, s2]),]
            c2 = [tuple([s1]), tuple([s2])]
            
            C2.append(c1)
            C2.append(c2)
            
    return C2

def candidateGenSPM(Fkminus1, k):
    Ck = list()
    
    for i in range(len(Fkminus1) - 1):
        for j in range(i + 1, len(Fkminus1)):
            s1, s2 = Fkminus1[i], Fkminus1[j]
            c = compare2seq(s1, s2)
            c_subs = findSubseqs(c)
            
            flag = True
            for sub in c_subs:
                if sub not in Fkminus1:
                    flag = False
                    break
                
            if flag:
                Ck.append([tuple(x) for x in c])
            
    return Ck

def genC1(items):
    C1 = []
    
    for item in items:
        C1.append([])
        C1[-1].append(tuple([item]))
        
    return C1

def customiseS(S):
    s = []

    for i in range(len(S)):
        s.append([])
        s[-1].append(list(map(lambda x: tuple(x), S[i])))
        
    return s

def isSubset(s, s_sub):
    return set(s_sub).issubset(set(s))

def isSubseq(S, C):
    if len(S) <  len(C):
        return False

    i, j = 0, 0
    
    while i < len(S) and j < len(C):
        if isSubset(S[i], C[j]):
            i += 1
            j += 1
        else:
            i += 1

    return j == len(C)

def gsp(file, minsup):
    C, F = [-1], [-1]
    k = 2
    
    S, n = readData(file)
    supItems = initPass(S)
    
    C1 = genC1(list(supItems.keys()))
    F1 = genF1(supItems, n, minsup)
    
    C.append(C1)
    F.append(F1)
    # S = customiseS(S)
    
    while F[k - 1]:
        Ck = None
        
        if k == 2:
            Ck = candidateK2(F[1])
        else:
            Ck = candidateGenSPM(F[k - 1], k)
            
        cCount = {}
        for s in S:
            for c in Ck:
                if isSubseq(s, c):
                    cCount[tuple(c)] = cCount.get(tuple(c), 0) + 1
                    
        Fk = []
        for c in Ck:
            if tuple(c) in cCount:
                if cCount[tuple(c)]/n*100.0 >= minsup:
                    Fk.append(c)
            
        C.append(Ck)
        F.append(Fk)
        k += 1
    
    print(C)
    print()
    print(F)

gsp('data.txt', 25.0)