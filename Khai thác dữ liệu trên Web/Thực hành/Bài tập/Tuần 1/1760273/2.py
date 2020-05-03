import sys

# main
fileIn = sys.argv[1]
fileOut = sys.argv[2]

f = open(fileIn, 'r')

arr = list(map(int, f.read().split()))
arr.sort()

w = ' '.join(map(str, arr))

f.close()

f = open(fileOut, 'w')
f.write(w)
f.close()