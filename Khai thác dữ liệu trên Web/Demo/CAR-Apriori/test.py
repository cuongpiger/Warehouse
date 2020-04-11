import itertools

def readData(file):
    supItems = {}
    T = {}
    n = 0
    
    f = open(file, 'r')
    trans = f.readline().strip()
    
    while trans != '':
        n += 1
        trans = trans.split()
        T[trans[-1]] = T.get(trans[-1], []) + [trans[:-1]]
        
        for i in range(len(trans) - 1):
            supItems[trans[i]] = supItems.get(trans[i], 0) + 1
            
        trans = f.readline().strip()
        
    f.close()
    
    return (T, supItems, n)

def isSubset(s, s_sub):
    return set(s_sub).issubset(set(s))

def ruleSupCount(T, f):
    res = {}
    
    for cls, trans in T.items():
        for t in trans:
            if isSubset(t, f):
                res[cls] = res.get(cls, 0) + 1
                
    return res

def condSupCount(T, condset):
    csc = 0
    
    for trans in T.values():
        for t in trans:
            if isSubset(t, condset):
                csc += 1
                
    return csc

def genF1(T, C1, supItems, n, minsup):
    F1 = {}
    
    for f in C1:
        rsc = ruleSupCount(T, [f])
        
        for cls, val in rsc.items():
            if val/n*100.0 >= minsup:
                F1[tuple([f, cls])] = (supItems[f], val)
                
    return F1

def genCar1(T, F1, minconf):
    Car1 = {}
    
    for fKey, fValue in F1.items():
        if fValue[1]/condSupCount(T, list(fKey[:-1]))*100.0 >= minconf:
            Car1[fKey] = (fValue[1], fValue[0])
    
    return Car1

def findSubsets(s, n): 
    return list(map(list, itertools.combinations(s, n)))

def candidateGen(Fkminus1, k):
    Ck = []
    
    for i in range(len(Fkminus1) - 1):
        for j in range(i + 1, len(Fkminus1)):
            f1, f2 = list(Fkminus1[i][:-1]), list(Fkminus1[j][:-1])
            
            if f1[:-1] == f2[:-1] and Fkminus1[i][-1] == Fkminus1[j][-1]:
                c = f1 + [f2[-1]]
                c_subs = findSubsets(c, k - 1)
                
                F = list(map(lambda x: list(x[:-1]), Fkminus1))

                flag = True
                for sub in c_subs:
                    if sub not in F:
                        flag = False
                        break
                        
                if flag:
                    Ck.append(c + [Fkminus1[j][-1]])
                    
    return Ck

def printResult(C, F, Car):
    print('Bảng C:')
    print('_'*20)
    for i in range(1, len(C)):
        print('C{0}'.format(i))

        for itm in C[i]:
            print(itm)

        print('-'*20)

    print('\nBảng F:')
    print('_'*20)
    for i in range(1, len(F)):
        print('F{0}'.format(i))

        for key, value in F[i].items():
            print('{0} - {1}'.format(key, value))

        print('-'*20)

    print('\nBảng Car:')
    print('_'*20)
    for i in range(1, len(Car)):
        print('Car{0}'.format(i))

        for key, value in Car[i].items():
            print('{0} - conf = {1}/{2}'.format(key, value[0], value[1]))

        print('-'*20)

def carApriori(T, supItems, n, minsup, minconf):
    C, F, Car = [-1], [-1], [-1]
    k = 2
    
    C1 = list(supItems.keys())
    F1 = genF1(T, C1, supItems, n, minsup)
    Car1 = genCar1(T, F1, minconf)
    
    C.append(C1)
    F.append(F1)
    Car.append(Car1)
    
    while F[k - 1]:
        Ck = candidateGen(list(F[k - 1].keys()), k)   

        condSup, ruleSup = {}, {}
        for key, trans in T.items():
            for t in trans:
                for c in Ck:
                    if isSubset(t, c[:-1]):
                        condSup[tuple(c[:-1])] = condSup.get(tuple(c[:-1]), 0) + 1

                        if key == c[-1]:
                            ruleSup[tuple(c)] = ruleSup.get(tuple(c), 0) + 1

        Fk = {}

        for c in Ck:
            if ruleSup[tuple(c)]/n*100.0 >= minsup:
                Fk[tuple(c)] = (condSup[tuple(c[:-1])], ruleSup[tuple(c)])

        CarK = {}

        for fKey, fValue in Fk.items():
            if ruleSup[fKey]/condSup[fKey[:-1]]*100 >= minconf:
                CarK[fKey] = (ruleSup[fKey], condSup[fKey[:-1]])

        C.append(Ck)
        F.append(Fk)
        Car.append(CarK)
        k += 1
    
    printResult(C, F, Car)

def solve(file, minsup, minconf):
    T, supItems, n = readData(file)
    carApriori(T, supItems, n, minsup, minconf)

solve('data.txt', 20.0, 30.0)